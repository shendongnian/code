            int[,] grid = new int[3, 3];
            Random randomNumber = new Random();
            var rowLength = grid.GetLength(0);
            var colLength = grid.GetLength(1);
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    grid[row, col] = randomNumber.Next(6);
                }
            }
            //  Now, we have the grid with 0's, time to play Tetris with the 0's.
            for (int row = rowLength - 1; row >= 0; row--)
            {
                for (int col = 0; col < colLength; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        for (int currentRow = row; currentRow >= 0; currentRow--)
                        {
                            if (currentRow == 0)
                                grid[currentRow, col] = randomNumber.Next(1, 6);
                            else
                            {
                                grid[currentRow, col] = grid[currentRow - 1, col];
                            }
                        }
                    }
                }
            }
