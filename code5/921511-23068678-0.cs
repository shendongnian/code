    public static object GetPropValue(object src, string propName)
    {
        var propertyInfo = src.GetType().GetProperty(propName);
        if (propertyInfo.GetGetMethod().IsStatic)
            return propertyInfo.GetValue(null, null);
        else
            return propertyInfo.GetValue(src, null);
    }
