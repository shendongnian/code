     static void Main()
            {
                int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
                int[,] arr2 = new int[2, 2];
    
                var columnToRemove = 2;
                var rowToRemove = 0;
                for (int i = 0, j = 0; i < array.GetLength(0); i++)
                {
                    if (i == rowToRemove)
                        continue;
    
                    for (int k = 0, u = 0; k < array.GetLength(1); k++)
                    {
                        if (k == columnToRemove)
                            continue;
    
                        arr2[j, u] = array[i, k];
                        u++;
                    }
                    j++;
                }
            }
