    public static IQueryable<T> WherePropertyIsIn<T, TSet>(
        this IQueryable<T> query,
        IEnumerable<TSet> set,
        Expression<Func<T, TSet>> propertyExpression
    ) {
        var filterPredicate = set.Select(value => Expression.Equal(propertyExpression.Body, Expression.Constant(value)))
            .Aggregate<Expression, Expression>(Expression.Constant(false), Expression.Or);
        var filterLambdaExpression = Expression.Lambda<Func<T, bool>>(filterPredicate, propertyExpression.Parameters.Single());
        return query.Where(filterLambdaExpression);
    }
