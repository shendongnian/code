    public static Expression<Func<T>> Wrap<T>(Func<T> f)
    {
        return Expression.Lambda<Func<T>>(
            Expression.Invoke(Expression.Constant(f))
        );
    }
    public static Expression<Func<T1, T2>> Wrap<T1, T2>(Func<T1, T2> f)
    {
        var p1 = Expression.Parameter(typeof (T1));
        return Expression.Lambda<Func<T1, T2>>(
            Expression.Invoke(Expression.Constant(f), p1), 
            new[] { p1 }
        );
    }
