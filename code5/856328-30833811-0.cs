    int count = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int x = 0; x < 8-i-1; x++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < i*2+1; j++)
                    {
                        Console.Write("X");
                    }
                    Console.WriteLine();
                }
                //solution to your stump problem
                for (int i = 0; i < 4; i++)//the no. 4 means that you stump will be made from four X's
                {
                     for (int x = 0; x < 8-count-1; x++)
                    {
                        Console.Write(" ");
                        
                    }
                     Console.Write("X");
                     Console.WriteLine();
                }
                Console.ReadKey();
