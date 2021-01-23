    public static Expression<Func<TItem, bool>> PropertyEquals<TItem, TValue>(
        PropertyInfo property, TValue value)
    {
        var param = Expression.Parameter(typeof(TItem));
        var body = Expression.Equal(Expression.Property(param, property),
            Expression.Constant(value));
        return Expression.Lambda<Func<TItem, bool>>(body, param);
    }
