    public static class Extensions
    {
        public static IEnumerable<T> EndToEnd(this IList<T> source)
        {
            var length = source.Count;
            if (length == 0)
            {
                yield break;
            }
        
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
