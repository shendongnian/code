    public static T GetObject<T>(IDictionary<string, object> dict)
    {
        Type type = typeof(T);
        var obj = Activator.CreateInstance(type);
        foreach (var kv in dict)
        {
            type.GetProperty(kv.Key).SetValue(obj, kv.Value);
        }
        return (T)obj;
    }
