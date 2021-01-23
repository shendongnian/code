     int index = 20;
                for (int i = 0; i < 20; i++)
                {
                    for (int k = 0; k < 20 - index; k++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < index; j++)
                    {
                        Console.Write("*");
                    }
                    for (int k = 0; k < index; k++)
                    {
                        Console.Write("*");
                    }
                    
                    index--;
                    Console.WriteLine();
                }
                Console.ReadLine();
 
