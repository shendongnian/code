    public static dynamic ToExpando(this IDictionary<string, object> dictionary)
    {
        dynamic expando = new ExpandoObject();
        var expandoDic = (IDictionary<string, object>)expando;
        // go through the items in the dictionary and copy over the key value pairs)
        foreach (var kvp in dictionary)
        {
            // if the value can also be turned into an ExpandoObject, then do it!
            if (kvp.Value is IDictionary<string, object>)
            {
                var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
                expandoDic.Add(kvp.Key, expandoValue);
            }
            else if (kvp.Value is ICollection)
            {
                // iterate through the collection and convert any strin-object dictionaries
                // along the way into expando objects
                var itemList = new List<object>();
                foreach (var item in (ICollection)kvp.Value)
                {
                    if (item is IDictionary<string, object>)
                    {
                        var expandoItem = ((IDictionary<string, object>)item).ToExpando();
                        itemList.Add(expandoItem);
                    }
                    else
                    {
                        itemList.Add(item);
                    }
                }
                expandoDic.Add(kvp.Key, itemList);
            }
            else
            {
                expandoDic.Add(kvp);
            }
        }
        return expando;
    }
