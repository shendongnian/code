    public static class ArrayExtensions
    {
        public static IEnumerable<IEnumerable<T>> Columns<T>(this T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            return Enumerable.Range(0, array.GetLength(1))
                .Select(iCol => Enumerable.Range(0, array.GetLength(0))
                    .Select(iRow => array[iRow, iCol]));
        }
        public static IEnumerable<IEnumerable<T>> Rows<T>(this T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            return Enumerable.Range(0, array.GetLength(0))
                .Select(iRow => Enumerable.Range(0, array.GetLength(1))
                    .Select(iCol => array[iRow, iCol]));
        }
    }
