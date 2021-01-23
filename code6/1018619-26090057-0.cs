    public static Expression<Func<T, object>> GetSortLambda<T>(string propertyPath)
    {
        var param = Expression.Parameter(typeof(T), "p");
        var parts = propertyPath.Split('.');
        Expression parent = param;
        foreach (var part in parts)
        {
            parent = Expression.Property(parent, part);
        }
        if (parent.Type.IsValueType)
        {
            var converted = Expression.Convert(parent, typeof(object));
            return Expression.Lambda<Func<T, object>>(converted, param);
        }
        else
        {
            return Expression.Lambda<Func<T, object>>(parent, param);
        }
    }
