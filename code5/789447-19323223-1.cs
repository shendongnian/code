    public static IQueryable<TSource> WhereIn<TSource, TKey>(
        this IQueryable<TSource> query,
        Expression<Func<TSource, TKey>> propertySelector,
        IEnumerable<TKey> values)
    {
        var t = Expression.Parameter(typeof(TSource));
        Expression body = Expression.Constant(false);
        var propertyName = ((MemberExpression)propertySelector.Body).Member.Name;
        foreach (var value in values)
        {
            body = Expression.OrElse(body,
                Expression.Equal(Expression.Property(t, propertyName),
                    Expression.Constant(value)));
        }
        return query.Where(Expression.Lambda<Func<TSource, bool>>(body, t));
    }
