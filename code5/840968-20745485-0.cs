    var obj = new example { ... };
    var result = new List<string>();
    foreach (var property in TypeDescriptor.GetProperties(obj))
    {
        result.Add(property.Name + "=" + property.GetValue(obj));
    }
    
    return string.Join("&", result);
