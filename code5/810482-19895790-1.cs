    public void DoStuff<TModel, TCollection>()
    {
        foreach (var property in typeof(TModel).GetProperties())
        {
            var itemType = GetListType(property.PropertyType);
            if(itemType == typeof(TCollection))
            {
                // this is the property we need
            }
        }
    }
