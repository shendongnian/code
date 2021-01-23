        public static T[,] To2DArray<T>(this T[][] arr)
        {
            if (arr.Length == 0)
            {
                return new T[,]{};
            }
            int standardLength = arr[0].Length;
            foreach (var x in arr)
            {
                if (x.Length != standardLength)
                {
                    throw new ArgumentException("Arrays must have all the same length");
                }
            }
            T[,] solution = new T[arr.Length, standardLength];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < standardLength; j++)
                {
                    solution[i, j] = arr[i][j];
                }
            }
            return solution;
        }
