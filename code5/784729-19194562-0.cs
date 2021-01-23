    public static HashSet<Type> GetPropertyTypes(Type type)
    {
        return new HashSet<Type>(type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                     .Select(prop => prop.PropertyType));
    }
