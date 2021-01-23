    public static T[] Deserialize<T>(string value)
    {
        return value.FromJson(value, typeof(T)) as T;
    }
    public static T[] DeserializeArray<T>(string value)
    {
        return Deserialize<T[]>(value);
    }
