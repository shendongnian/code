     int[] MatrixMul(string input, int[,] key)
            {
                int[] result = new int[input.Length];
                for (int row = 0; row < key.GetLength(0); row++)
                {
                    for (int col = 0; col < key.GetLength(0); col++)
                    {
                       result[row]+= key[row, col] * AtoZ.IndexOf(input[col]);
                        
                    }
                    
                }
                return result;
            }
