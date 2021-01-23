    public static IOrderedQueryable<T> AddOrdering<T, TKey>(
    this IQueryable<T> source,
    Expression<Func<T, TKey>> keySelector,
    bool descending)
    {
    // If it's not ordered yet, use OrderBy/OrderByDescending.
    if(source.Expression.Type != typeof(IOrderedQueryable<T>))
    {
        return descending ? source.OrderByDescending(keySelector)
                          : source.OrderBy(keySelector);
    }
    // Already ordered, so use ThenBy/ThenByDescending
    return descending ? ((IOrderedQueryable<T>)source).ThenByDescending(keySelector)
                      : ((IOrderedQueryable<T>)source).ThenBy(keySelector);
    }
