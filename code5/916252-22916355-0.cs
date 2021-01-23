    public static Expression<Func<T, bool>> PropertyEquals<T>(
        string propertyName, string valueToCompare)
    {
        var param = Expression.Parameter(typeof(T));
        var body = Expression.Equal(Expression.Property(param, propertyName)
            , Expression.Constant(valueToCompare));
        return Expression.Lambda<Func<T, bool>>(body, param);
    }
