     static void Main()
            {
                int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
                var trim = TrimArray(0, 2, array);
            }
    
    
            public static int[,] TrimArray(int rowToRemove, int columnToRemove, int[,] originalArray)
            {
                int[,] result = new int[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];
    
                for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
                {
                    if (i == rowToRemove)
                        continue;
    
                    for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                    {
                        if (k == columnToRemove)
                            continue;
    
                        result[j, u] = originalArray[i, k];
                        u++;
                    }
                    j++;
                }
    
                return result;
            }
