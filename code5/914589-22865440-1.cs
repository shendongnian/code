    var flags = BindingFlags.Public | BindingFlags.Instance;
    _propertyMap = _types.SelectMany(t => t.GetProperties(flags))
                         .GroupBy(p => p.Name)
                         .ToDictionary(g => g.Key, 
                                       g => g.Select(p => p.DeclaringType).ToList());
