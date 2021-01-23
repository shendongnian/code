    public static Expression<Func<T, bool>> GetPropertyCondition<T>(T source, string prop)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var trueExp = Expression.Constant(true);
        var condition = Expression.Equal(
                            Expression.Property(
                                Expression.Property(param, "t2"), prop),
                                trueExp);
        var whereLambda = Expression.Lambda<Func<T, bool>>(condition, param);
        return whereLambda;
    }
