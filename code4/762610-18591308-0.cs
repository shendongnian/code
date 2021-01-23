    public static T GetAttributeValue<T>(this DbElement element, DbAttribute attribute, T defaultValue)
    {
        if (typeof(T) == typeof(DbAttribute))
        {
            var dbAttribute = default(DbAttribute);
            if (element.GetValidAttribute(attribute, ref dbAttribute)) return (T)(object)dbAttribute;
        }
        else if (typeof(T) == typeof(bool))
        {
            var boolResult = default(bool);
            if (element.GetValidBool(attribute, ref boolResult)) return (T)(object)boolResult;
        }
        return defaultValue;
    }
