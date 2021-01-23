    public static dynamic ToDynamic(this object @this)
    {
        IDictionary<string, object> expando = new ExpandoObject();
    
        foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(@this.GetType()))
        {
            expando.Add(property.Name, property.GetValue(@this));
        }
    
        return expando as ExpandoObject;
    }
