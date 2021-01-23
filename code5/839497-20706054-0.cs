    public static string UpdateCommand<T>(Func<IEnumerable<PropertyInfo>, IEnumerable<PropertyInfo>> filterFunc = null)
    {
        IEnumerable<PropertyInfo> properties = typeof(T).GetProperties();
        if (filterFunc != null)
            properties = filterFunc(properties);
        ...
    }
