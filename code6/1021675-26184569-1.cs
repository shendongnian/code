    public static T ConvertToClass<T>(this Dictionary<string, object> model)
    {
        Type type = typeof(T);
        var obj = Activator.CreateInstance(type);
        foreach (var item in model)
        {                              
           type.GetProperty(item.Key).SetValue(obj, item.Value);
        }
        return (T)obj;
    }
