    public static T Convert<T>(String value)
    {
        if (typeof(T).IsEnum)
           return (T)Enum.Parse(typeof(T), value);
        return (T)Convert.ChangeType(value, typeof(T));
    }
