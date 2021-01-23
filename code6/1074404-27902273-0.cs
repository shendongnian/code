    public static IEnumerable<PropertyInfo> GetRuntimeProperties(this Type type)
    {
        CheckAndThrow(type);
        IEnumerable<PropertyInfo> properties = type.GetProperties(everything);
        return properties;
    }
