    public IEnumerable<string> GetAllPropertyNames(object o)
    {
        foreach (PropertyInfo propInfo in o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        yield return propInfo.Name;
    }
