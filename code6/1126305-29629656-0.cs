    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.SetCursorPosition(j,i);
                        if (j - i > 0 && j+i < 6)
                        {
                            Console.Write("*");
                        }
                    }
                }
                Console.ReadLine();
            }
    
        }
    }
