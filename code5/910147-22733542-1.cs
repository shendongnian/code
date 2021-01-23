    Type t = myResult.GetType();
    PropertyInfo[] props = t.GetProperties();
    Dictionary<string, object> dict = new Dictionary<string, object>();
    foreach (PropertyInfo prp in props)
    {
       object value = GetPropValue(myResult, prp.Name);
       dict.Add(prp.Name, value);
    }
    
    public static object GetPropValue(object src, string propName)
    {
       return src.GetType().GetProperty(propName).GetValue(src, null);
    }
