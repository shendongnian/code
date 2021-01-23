    public static dynamic ConvertObjectToDynamic(object value)
    {
        if (value == null)
        {
            return null;
        }
        IDictionary<string, object> dynamicObject = new ExpandoObject();
        var properties = value.GetType().GetProperties(
            BindingFlags.Public | BindingFlags.Instance);
        foreach (var propertyInfo in properties)
        {
            if (propertyInfo.GetIndexParameters().Length == 0)
            {
                var propertyValue = propertyInfo.GetValue(value);
                dynamicObject[propertyInfo.Name] = propertyValue;
            }
        }
        return dynamicObject;
    }
