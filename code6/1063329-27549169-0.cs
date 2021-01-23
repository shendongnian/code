    if (reflectionType == "GetProperty")
    {
        var getPropertyInfoDelegate = new Func<string, PropertyInfo>(obj.GetType().GetType().GetProperty);
        PropertyInfo propertyInfo = getPropertyInfoDelegate(propertyName);
    }
