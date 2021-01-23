    public static class Extensions
    {
        public static int MaxId<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source.Any())
            {
                return source.Max(selector);
            }
            
            return 0;
        }
    }
