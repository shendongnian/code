    public static Expression GetSelector<T>(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.Property(parameter, 
            typeof(T).GetProperty(propertyName));
        return Expression.Lambda(body, parameter);
    }
