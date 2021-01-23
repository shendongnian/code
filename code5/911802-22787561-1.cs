    var custom = new ArrayList();    
    
    foreach(var item in items)
    {
        // invert the check
        if (!object.ReferenceEquals(item, data))
        {
           // add on the custom result
           custom.Add(item);
        }
    }
    
    return custom;
