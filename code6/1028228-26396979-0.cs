    public static T ConvertNumericStringObj<T>(string value)
    {
        var t = typeof (T);
        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            if (string.isNullOrEmpty(value))
                return default(T);
            t = Nullable.GetUnderlyingType(t);
        }
        return (T)Convert.ChangeType(value, t);
    }
