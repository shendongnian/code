    public static T GetValue<T>(this DynamicClass dynamicObject, string propName)
    {
        if (dynamicObject == null)
        {
            throw new ArgumentNullException("dynamicObject");
        }
    
        var type = dynamicObject.GetType();
        var props = type.GetProperties(BindingFlags.Public 
                                     | BindingFlags.Instance 
                                     | BindingFlags.FlattenHierarchy);
        var prop = props.FirstOrDefault(property => property.Name == propName);
        if (prop == null)
        {
            throw new InvalidOperationException("Specified property doesn't exist.");
        }
    
        return (T)prop.GetValue(dynamicObject, null);
    }
    
    public static string ToDynamicSelector(this IList<string> propNames)
    {
       if (!propNames.Any()) 
           throw new ArgumentException("You need supply at least one property");
       return string.Format("new({0})", string.Join(",", propNames));
    }
