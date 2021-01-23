    var itemType = GetListType(p.PropertyType);
    if(itemType != null)
    {
        var list = (IList) p.GetValue(obj);
        foreach(EntityBase item in list)
        {
            // ...
        }
    }
