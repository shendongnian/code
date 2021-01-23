    var allEnumTypes = Assembly.GetExecutingAssembly()
                               .GetTypes()
                               .Where(t => t.IsEnum);
    
    foreach(var enumType in allEnumTypes)
    {
        var syncAttr = Attribute.GetCustomAttribute(enumType, typeof(EnumSyncAtrribute)) as EnumSyncAtrribute;
        if (syncAttr != null)
        {
            // Possibly do something here, but the constructor was already executed at this point.
        }
    }
