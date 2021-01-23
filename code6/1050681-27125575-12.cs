    public static class Extensions
    {
        public static IEnumerable<T> EndToEnd<T>(this IReadOnlyList<T> source)
        {
            var c = source.Count;
            for (int i = 0, f = 0, l = c - 1; i < c; i++, f++, l--)
            {
                yield return source[f];
                if (++i == c)
                {
                   break;
                }
               
                yield return source[l];
            }
        }
    }
