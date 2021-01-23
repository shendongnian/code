    var value = p.GetValue(obj);
    Type itemType;
    if(value is IList && (itemType = GetListType(p.PropertyType) != null)
          && itemType.IsSubclassOf(typeof(EntityBase)))
    {
        var list = (IList)value;
        foreach(EntityBase item in list)
        {
            // ...
        }
    }
