    public object GetPropValue(object obj, string propName)
    {
        var property = obj.GetType()
                          .GetProperties()
                          .SingleOrDefault(p=>p.Name.Equals(propName, StringComparison.OrdinalIgnoreCase));
    
        return property != null ? property.GetValue(obj, null) : null;
    }
