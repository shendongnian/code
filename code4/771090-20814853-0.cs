        public static void Sort2DArray<T>(T[,] matrix)
        {
            var numb = new T[matrix.GetLength(0) * matrix.GetLength(1)];
            int i = 0;
            foreach (var n in matrix)
            {
                numb[i] = n;
                i++;
            }
            Array.Sort(numb);
            int k = 0;
            for (i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numb[k];
                    k++;
                }
            }
        }
