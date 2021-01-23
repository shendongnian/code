    Type t = myResult.GetType();
    PropertyInfo[] props = t.GetProperties();
    Dictionary<string, object> dict = new Dictionary<string, object>();
    foreach (PropertyInfo prp in props)
    {
        object value = prp.GetValue(myResult, new object[]{});
        dict.Add(prp.Name, value);
    }
         
  
