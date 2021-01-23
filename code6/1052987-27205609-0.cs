    public static class RectangularArrayExtensions
    {
        public static IEnumerable<T> Cast<T>(this T[,] source)
        {
            foreach (T item in source)
            {
                yield return item;
            }
        }
    }
