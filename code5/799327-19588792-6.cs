    public static class MyExtensions
    {
        public static IEnumerable<List<T>> ToEnumerableOfEnumerable<T>(this T[,] array)
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var row = new List<T>();
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    row.Add(array[rowIndex, columnIndex]);
                }
                yield return row;
            }
        }
        public static T[,] ToTwoDimensionalArray<T>(this List<List<T>> tuples)
        {
            var list = tuples.ToList();
            T[,] array = null;
            for (int rowIndex = 0; rowIndex < list.Count; rowIndex++)
            {
                var row = list[rowIndex];
                if (array == null)
                {
                    array = new T[list.Count, row.Count];
                }
                for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
                {
                    array[rowIndex, columnIndex] = row[columnIndex];
                }
            }
            return array;
        }
    }
