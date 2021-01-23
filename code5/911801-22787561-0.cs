    var custom = items.ToList();
    
    foreach(var item in items)
    {
        if (object.ReferenceEquals(item, data))
        {
           custom.Remove(item);
           // something like this items.Remove(item); should happen here
        }
    }
    
    return custom;
