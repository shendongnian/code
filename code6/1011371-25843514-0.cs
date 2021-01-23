    var properties = typeof (InMemoryContext)
        .GetProperties()
        .Where(p => p.PropertyType.IsInterface &&
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GetGenericTypeDefinition() == typeof (IDbSet<>));
    var values = properties.Select(p => p.GetValue(this));
