    public static T GetAttribute<T>(this object instance, string propertyName) where T : Attribute
    {
        var attrType = typeof(T);
        var property = instance.GetType().GetProperty(propertyName);
        return (T)property .GetCustomAttributes(attrType, false).First();
    }
