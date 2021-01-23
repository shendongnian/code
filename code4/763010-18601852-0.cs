    public enum SortDirection { Ascending, Descending }
    
    public static class Extensions
    {
        public static IEnumerable<TSource> SortBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            SortDirection sortDirection,
            Func<TSource, TKey> keySelector)
        {
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    return source.OrderBy(keySelector);
                case SortDirection.Descending:
                    return source.OrderByDescending(keySelector);
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }
