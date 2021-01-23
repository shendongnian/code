    using System;
    
    namespace ConsoleTest
    {
        class Program
        {
            struct Säljare
            {
                public int artiklar;
            }
    
            static void Main(string[] args)
            {
                Säljare[] s = new Säljare[6];
    
                for (int x = 0; x <= 5; x++)
                {
                    Console.Write("Antal sålda artiklar: ");
                    s[x].artiklar = int.Parse(Console.ReadLine());
                }
    
                Console.WriteLine(s.Length);
    
                int[,] kategori = new int[2, 6];
    
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
    
                    else if (50 <= s[y].artiklar)
                    {
                        kategori[1, b] = y;
                        b++;
                    }
    
                    y++;
                }
    
                //Use this to print kategori
                for (a = 0; a < 2; a++)
                {
                    for (b = 0; b < 6; b++)
                    {
                        Console.Write("{0}\t", kategori[a, b]);
                    }
                    Console.WriteLine();
                }
    
                Console.WriteLine("Antal");
    
                int z = 0;
                for (int x = 0; x < a; x++)
                {
                    kategori[0, x] = z; //z is always 0
                    Console.WriteLine(s[z].artiklar);
                }
    
                for (int x = 0; x < b; x++)
                {
                    kategori[1, x] = z; //z is always 0
                    Console.WriteLine(s[z].artiklar);
                }
                Console.ReadKey();
            }
        }
    }
