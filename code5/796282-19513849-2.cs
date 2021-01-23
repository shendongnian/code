    var value = p.GetValue(obj);
    if(value is IList && GetListType(p.PropertyType) != null)
    {
        var list = (IList)value;
        foreach(EntityBase item in list)
        {
            // ...
        }
    }
