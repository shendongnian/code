    public static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object myObject)
    {
        var properties = 
            from   property in myObject.GetType().GetProperties()
            where  property.PropertyType == typeof(T) && property.CanRead
            select new KeyValuePair<string, T>(property.Name, (T)property.GetValue(myObject));
        return properties;
    }
