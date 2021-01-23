    public static object GetPropValue(this object o, string propName)
    {
        return o.GetType().GetProperty(propName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                .GetValue(o);
    }
