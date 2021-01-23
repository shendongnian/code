    public static Expression<Func<TSource, bool>> GetPropertyContainsValueExpression<TSource>(string propertyName, string value)
    {
        var param = Expression.Parameter(typeof(TSource), "x");
        var prop = Expression.Property(param, propertyName);
        var valueExp = Expression.Constant(value, typeof(string));
        var contains = Expression.Call(prop, "Contains", null, valueExp);
        return Expression.Lambda<Func<TSource, bool>>(contains, param);
    }
