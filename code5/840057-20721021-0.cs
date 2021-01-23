        public void PrintArr()
        {
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < 4; j++)
                        Console.Write(_arr[i, j] + " ");
                    Console.WriteLine();
                }
                else
                {
                    for (int j = 3; j >= 0; j--)
                        Console.Write(_arr[i, j] + " ");
                    Console.WriteLine();
                }
            }
        }
