    public static Expression<Func<T, IEnumerable<TResult>>> AsSequence<T, TResult>(
        this IEnumerable<Expression<Func<T, TResult>>> expressions)
    {
        var param = Expression.Parameter(typeof(T));
        var body = Expression.NewArrayInit(typeof(TResult),
            expressions.Select(selector =>
                selector.Body.Replace(selector.Parameters[0], param)));
        return Expression.Lambda<Func<T, IEnumerable<TResult>>>(body, param);
    }
