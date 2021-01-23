    public static IEnumerable<TSource> SafeFilter<TSource, TKey>
        (this IQueryable<TSource> source,
        Expression<Func<TSource, TKey>> keySelector,
        HashSet<TKey> filterSet,
        int threshold = 500)
    {
        if (filterSet.Count > threshold)
        {
            var selector = keySelector.Compile();
            return source.AsEnumerable()
                .Where(x => filterSet.Contains(selector(x))); //In memory
        }
        return source.Where(keySelector.Compose(
            key => filterSet.AsEnumerable().Contains(key)));     //In SQL
    }
