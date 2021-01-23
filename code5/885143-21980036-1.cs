    public static object GetDefaultValue(Type t)
    {
        if (!t.IsValueType || Nullable.GetUnderlyingType(t) != null)
            return null;
    
        return Activator.CreateInstance(t);
    }
