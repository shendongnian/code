    public static IQueryable<T> WhereEquals<T>(
        this IQueryable<T> query,
        string property,
        object valueToCompare)
    {
        var param = Expression.Parameter(typeof(T));
        var body = Expression.Equals(
            Expression.Property(param, property),
            Expression.Constant(valueToCompare));
        var lambda = Expression.Lambda<Func<T, bool>>(body, param);
        return query.Where(lambda);
    }
