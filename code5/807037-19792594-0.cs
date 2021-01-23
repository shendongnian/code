    public static Expression<Func<T1, TResult>> ToSimpleFunc<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> f, T2 value)
    {
        var invokeExpression = Expression.Invoke(f, f.Parameters[0], Expression.Constant(value));
        return Expression.Lambda<Func<T1, TResult>>(invokeExpression, f.Parameters[0]);
    }
