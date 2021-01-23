    var obj = new example { ... };
    var result = new List<string>();
    foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
    {
        result.Add(property.Name + "=" + property.GetValue(obj));
    }
    
    return string.Join("&", result);
