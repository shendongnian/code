    public IEnumerable<Func<T, string>> GetPropertyFunctions<T>()
    {
        var stringProperties = GetStringPropertyFunctions<T>();
        var decimalProperties = GetDecimalPropertyFunctions<T>();
        return stringProperties.Concat(decimalProperties);
    }
    public IEnumerable<Func<T, string>> GetStringPropertyFunctions<T>()
    {
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(p => p.PropertyType == typeof(string)).ToList();
        var properties = propertyInfos.Select(GetStringPropertyFunc<T>);
        return properties;
    }
    public Func<T, string> GetStringPropertyFunc<T>(PropertyInfo propInfo)
    {
        ParameterExpression x = System.Linq.Expressions.Expression.Parameter(typeof(T), "x");
        Expression<Func<T, string>> expression = System.Linq.Expressions.Expression.Lambda<Func<T, string>>(System.Linq.Expressions.Expression.Property(x, propInfo), x);
        Func<T, string> propertyAccessor = expression.Compile();
        return propertyAccessor;
    }
    public IEnumerable<Func<T, string>> GetDecimalPropertyFunctions<T>()
    {
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(p => p.PropertyType == typeof(decimal)).ToList();
        var properties = propertyInfos.Select(GetDecimalPropertyFunc<T>);
        return properties;
    }
    public Func<T, string> GetDecimalPropertyFunc<T>(PropertyInfo propInfo)
    {
        ParameterExpression x = System.Linq.Expressions.Expression.Parameter(typeof(T), "x");
        Expression<Func<T, decimal>> expression = System.Linq.Expressions.Expression.Lambda<Func<T, decimal>>(System.Linq.Expressions.Expression.Property(x, propInfo), x);
        Func<T, decimal> propertyAccessor = expression.Compile();
        return (T item) => propertyAccessor(item).ToString();
    }
