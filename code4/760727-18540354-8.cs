    public static class Extensions
    {
        public static int MaxId<TSource>(this IQueryable<TSource> source, Func<TSource, int> selector)
        {
            return source.Select(selector).DefaultIfEmpty(0).Max();
        }
    }
