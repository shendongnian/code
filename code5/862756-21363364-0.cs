    var prop = typeof(Rectangle).GetProperty("ID");
    if(prop.PropertyType.IsValueType)
    { 
       ..
    }
    prop = typeof(Rectangle).GetProperty("dimension");
    if(prop.PropertyType.IsInterface)
    {
       ...
    }
