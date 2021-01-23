    var itemType = GetListType(p.PropertyType);
    if(itemType != null && itemType.IsSubclassOf(typeof(EntityBase)))
    {
        var list = (IList) p.GetValue(obj);
        foreach(EntityBase item in list)
        {
            // ...
        }
    }
