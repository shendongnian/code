    public static Expression<Func<T, TResult>> Combine
        <T, TIntermediate1, TIntermediate2, TResult>(
    this Expression<Func<T, TIntermediate1>> first,
    Expression<Func<T, TIntermediate2>> second,
    Expression<Func<TIntermediate1, TIntermediate2, TResult>> resultSelector)
    {
        var param = Expression.Parameter(typeof(T));
        var body = resultSelector.Body.Replace(
                resultSelector.Parameters[0],
                first.Body.Replace(first.Parameters[0], param))
            .Replace(
                resultSelector.Parameters[1],
                second.Body.Replace(second.Parameters[0], param));
        return Expression.Lambda<Func<T, TResult>>(body, param);
    }
