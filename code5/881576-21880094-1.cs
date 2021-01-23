    Type objListType = null;
    if (kvp.Value is IEnumerable) {
        if (kvp.Value.GetType().IsArray) 
            objListType = kvp.Value.GetType().GetElementType();
        else
            objListType = kvp.Value.GetType().GetProperty("Item").PropertyType;
    }
