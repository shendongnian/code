    public static Expression<Func<T1, T3>> Combine<T1, T2, T3>(
        this Expression<Func<T1, T2>> first,
        Expression<Func<T2, T3>> second)
    {
        var param = Expression.Parameter(typeof(T1), "param");
        var newFirst = new ReplaceVisitor(first.Parameters.First(), param)
            .Visit(first.Body);
        var newSecond = new ReplaceVisitor(second.Parameters.First(), newFirst)
            .Visit(second.Body);
        return Expression.Lambda<Func<T1, T3>>(newSecond, param);
    }
