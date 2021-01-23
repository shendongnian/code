    public static IQueryable<T> ProjectionIsIn<T>(
        this IQueryable<T> source,
        IQueryable<string> collection,
        string columnName)
    {
        var param = Expression.Parameter(typeof(T));
        Expression<Func<string, bool>> containsExpression =
            s => collection.Contains(s);
        var predicateBody = containsExpression.Body.Replace(
                    containsExpression.Parameters[0],
                    Expression.Property(param, columnName));
        Expression<Func<T, bool>> predicate =
            Expression.Lambda<Func<T, bool>>(predicateBody, param);
        return source.Where(predicate);
    }
