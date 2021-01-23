    using System;
    
    namespace ConsoleTest
    {
        class Program
        {
            struct SomeStruct
            {
                public int artiklar;
            }
            static void Main(string[] args)
            {
                int[,] kategori = new int[2, 6];
    
                SomeStruct[] s = new SomeStruct[9];
                s[0].artiklar = 23;
                s[1].artiklar = 52;
                s[2].artiklar = 89;
                s[3].artiklar = 12;
                s[4].artiklar = 90;
                s[5].artiklar = 92;
                s[6].artiklar = 22;
                s[7].artiklar = 34;
                s[8].artiklar = 44;
    
                int a = 0;
                int b = 0;
    
                int y = 0;
    
                while (y < s.Length)
                {
                    if (s[y].artiklar < 50)
                    {
                        kategori[0, a] = y;
                        a++;
                    }
    
                    else if (50 <= s[y].artiklar && s[y].artiklar < 100)
                    {
                        kategori[1, b] = y;
                        b++;
                    }
                    y++;
                }
    
                for (a = 0; a < 2; a++)
                {
                    for (b = 0; b < 6; b++)
                    {
                        Console.Write("{0}\t", kategori[a, b]);
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
    }
