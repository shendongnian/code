    public static string GetName<T>(T Object)
        where T : IObjectWithName
    {
        return Object.Name;
    }
