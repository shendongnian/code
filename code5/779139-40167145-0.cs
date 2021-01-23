      public static IEnumerable<T> GetRow<T>(T[,] array, int row)
        {
            for (int i = 0; i <= array.GetUpperBound(1); ++i)
                yield return array[row, i];
        }
        public static IEnumerable<T> GetColumn<T>(T[,] array, int column)
        {
            for (int i = 0; i <= array.GetUpperBound(0); ++i)
                yield return array[i, column];
        }
