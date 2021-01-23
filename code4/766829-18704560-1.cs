    public static List<string> GetPropertyNames(this Object o)
    {
        List<string> names = new List<string>
        foreach (PropertyInfo prop in o.GetType().GetProperties())
            names.Add(prop.Name);
        return names;
    }
