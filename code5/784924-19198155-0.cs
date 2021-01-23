    for (int row = 1; row <= 25; row++) {
                    for (int col = 1; col <= 39; col++)
                    {
                        switch (row%3)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
        
                        }
                         Console.Write("* ");        
                        }
                    Console.WriteLine();
