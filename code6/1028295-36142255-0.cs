    public object GetPropValue(object obj, string propName)
    {
         return obj.GetType()
             .GetProperty(propName, BindingFlags.Instance | BindingFlags.IgnoreCase )
             .GetValue(obj, null);
    }
