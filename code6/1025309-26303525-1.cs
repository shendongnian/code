     public static double[,] fillNewArr(double[,] originalArr, int row, int col)
        {
            double[,] tempArray = new double[originalArr.GetLength(0) - 1, originalArr.GetLength(1) - 1];
            int newRow = 0;
            int newCol = 0;
            for (int i = 0; i < originalArr.GetLength(0); i++)
            {
                for (int j = 0; j < originalArr.GetLength(1); j++)
                {
                    if(i != row && j != col)
                    {
                        tempArray[newRow, newCol] = originalArr[i, j];
                        newRow++;
                        newCol++;
                    }
                    
                }
                
            }
            return tempArray;
 
        }
