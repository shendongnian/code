    static IEnumerable<PropertyInfo> FlattenProperties(Type type)
    {
        // Assumption #1: you do not want "simple" types enumerated
        if (!type.IsClass)
            return Enumerable.Empty<PropertyInfo>();
        // Assumption #2: you want to ignore "the usual suspects"
        if (type.Namespace.StartsWith("System"))
            return Enumerable.Empty<PropertyInfo>();
        
        // Assumption #3: your class hierarchy won't be destroyed by recursion
        // Assumption #4: you simply want the PropertyInfo
        return type.GetProperties(BindingFlags.FlattenHierarchy
                                | BindingFlags.Instance
                                | BindingFlags.Public)
                   .SelectMany(pi => new[] { pi }
                                  .Concat(FlattenProperties(pi.PropertyType)));
    }
