    public static T Convert<T>(string value)
    {
        if (typeof(T).GetTypeInfo().IsEnum)
            return (T)Enum.Parse(typeof(T), value);
        return (T)System.Convert.ChangeType(value, typeof(T));
    }
