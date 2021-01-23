    public static class Extensions
    {
        public static IEnumerable<T> EndToEnd<T>(this IReadOnlyList<T> source)
        {
            var length = source.Count;
            for (int r = 0, o = 0; r < length; r++, o++)
            {
                yield return source[o];
                r++;
                if (r == length)
                {
                   break;
                }
               
                yield return source[length - o - 1];
            }
        }
    }
