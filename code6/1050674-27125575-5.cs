    public static class Extensions
    {
        public static IEnumerable<T> EndToEnd<T>(this IReadOnlyList<T> source)
        {
            var length = source.Count;        
            var limit = length / 2;
            for (var i = 0; i < limit; i++)
            {
               yield return source[i];
               yield return source[length - i - 1];
            }
            if (length % 2 > 0)
            {
                yield return source[limit];
            }
        }
    }
