/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/.
*/

#if PERSONAL
string name = "Your crush's name";
#else
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Escribe tu nombre:");
Console.ResetColor();
string name = Console.ReadLine()!;
if (string.IsNullOrWhiteSpace(name)) name = "Love";
#endif

char heart = '♥';
int tab = 2;
int widht = 0;
List<string> result = [];

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Creando");
await Task.Delay(110);
for (int i = 0; i < 3; i++)
{
    Console.Write('.');
    await Task.Delay(110);
}
Console.Write('\n');
MakeHeart();
Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkRed;
#if PERSONAL
string nickname = "A cute nickname for your crush";
Console.WriteLine($"{new string(' ', widht / 2 - (4 + nickname.Length) / 2)}Te amo {nickname} {heart}\n\n");
#else
Console.WriteLine($"{new string(' ', widht / 2 - (4 + name.Length) / 2)}Te amo {name} {heart}\n\n");
#endif
ReplaceAndSend();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("\n\n\nOprima cualquier tecla para salir.");
Console.ReadKey();

void MakeHeart()
{

    Top();
    Mid();
    End();    

    void Top()
    {
        int line = 0;
        int lines = 4;

        /*result.Add(
            new string(' ', (lines - line) * tab + tab) +
            new string(heart, name.Length - tab) + 
            new string(' ', ((lines - line) * tab + tab) * 2 + 1) +
            new string(heart, name.Length - tab)
        );*/

        while (line <= lines)
        {
            string sLine = new string(' ', (lines - line) * tab);
            sLine += heart + new string('@', name.Length + line * (tab * 2)) + heart;
            sLine += new string(' ', (lines - line) * tab * 2 + 1);
            sLine += heart + new string('@', name.Length + line * (tab * 2)) + heart;
            result.Add(sLine);
            line++;

        }
    }

    void Mid()
    {
        for (int i = 0; i < 3; i++)
        {
            result.Add(heart + new string('@', result.Last().Length - 2) + heart);
        }
    }
    
    void End()
    {
        widht = result.Last().Length - 2;
        for (int i = tab; i * 2 < widht; i += tab)
        {
            string sLine = new string(' ', i);
            sLine += heart + new string('@', widht - (i * 2)) + heart;
            result.Add(sLine);
        }
        result.Add(new string(' ', widht / 2 + 1) + heart);
    }
}

void ReplaceAndSend()
{
    int index = 0;
    string.Join("\n", result).ToCharArray().ToList()
        .ForEach(c =>
        {
            if (c == '@')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(name[index % name.Length]);
                index++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(c);
            }
        });
}