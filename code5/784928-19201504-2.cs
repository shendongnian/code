            ConsoleColor[] colors = new ConsoleColor[] { 
            ConsoleColor.Yellow,
            ConsoleColor.Magenta,
            ConsoleColor.Green
            };
            for (int row = 1; row <= 25; row++)
            {
                Console.ForegroundColor = colors[(row+1) % 3];
                for (int col = 1; col <= 39; col++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
