    public static bool AllStringPropertyValuesAreNonEmpty(object myObject)
    {
        var allStringPropertyValues = 
            from   property in myObject.GetType().GetProperties()
            where  property.PropertyType == typeof(string) && property.CanRead
            select (string) property.GetValue(myObject);
        return allStringPropertyValues.All(value => !string.IsNullOrEmpty(value));
    }
