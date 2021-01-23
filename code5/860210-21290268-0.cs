    public static Dictionary<string, object> KeyValue(object obj)
    {
        return obj.GetType().GetProperties().ToDictionary(
            m => m.Name, 
            m => m.GetValue(obj, new object[] { })
        );
    }
