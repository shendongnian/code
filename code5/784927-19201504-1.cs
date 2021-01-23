            ConsoleColor[] colors = new ConsoleColor[] { 
            ConsoleColor.Green,            
            ConsoleColor.Yellow,
            ConsoleColor.Magenta
            };
            for (int row = 1; row <= 25; row++)
            {
                Console.ForegroundColor = colors[row % 3];
                for (int col = 1; col <= 39; col++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
