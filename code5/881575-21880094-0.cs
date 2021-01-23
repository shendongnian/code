    Type objListType = null;
    if (kvp.Value is IEnumerable) {
        if (kvp.Value.GetType().IsArray) 
            objListType = obj.GetType().GetElementType()
        else
            objListType = obj.GetType().GetProperty("Item").PropertyType
    }
