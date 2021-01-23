    int[,] array = new int[10, 5];
            Random rnd = new Random();
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    array[row, col] = rnd.Next(-50, 50);
                }
            }
