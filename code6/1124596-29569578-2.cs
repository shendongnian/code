    public static string GetName<T>(T Object)
    {
        if(Object is IEnumerable) throw new ArgumentException();
        xxxxxxx
    }
