    public bool Match<T>(T item, string searchTeam)
    {
        //You should cache the results of properties here for max perf.
        IEnumerable<Func<T, string>> properties = GetPropertyFunctions<T>();
        bool match = properties.Any(prop => prop(item) == "Foobar");
        return match;
    }
    public IEnumerable<Func<T, string>> GetPropertyFunctions<T>()
    {
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty).Where(p => p.PropertyType == typeof(string)).ToList();
        var properties = propertyInfos.Select(GetProperyFunc<User>);
        return properties;        
    }
    public Func<T, string> GetProperyFunc<T>(PropertyInfo propInfo)
    {
        ParameterExpression x = Expression.Parameter(typeof(User), "x");
        Expression<Func<User, string>> expression = Expression.Lambda<Func<User, string>>(Expression.Property(x, propInfo), x);
        Func<User, string> propertyAccessor = expression.Compile();
        return propertyAccessor;
    }
