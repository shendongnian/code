    using System;
    
    namespace Nimi
    {
        class Ohjelma
        {
            static void Main()
            {
                for (; ; )
                {
                    Console.Write("Anna korkeus: ");
                    string eka = Console.ReadLine();
                    int luku = int.Parse(eka);
                    //First, I made that if the number is 0 or lower, it will ask the number again. 
                    //Hence the endless loop at start.
                    if (luku <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        int i = 0;
    
                        while (i < luku)
                        {
                            int k = i + 1;
    
                            while (k < luku)
                            {
                                Console.Write(" ");
                                k++;
                            }
    
                            int j = 2 * i + 1;
    
                            while (j > 0)
                            {
                                Console.Write("*");
                                j--;
                            }
    
                            Console.WriteLine("");
    
                            i++;
                        }
    
                        break;
                    }
                }
            }
        }
    }
