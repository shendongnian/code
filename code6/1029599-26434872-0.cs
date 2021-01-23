    void UpdatePrice(ExpandoObject expando)
    {
        var map = (IDictionary<string, Object>)expando;
        if (map.ContainsKey("price"))
            map["price"] = 354.11D;
        foreach (var value in map.Values) 
        {
            if (value is ExpandoObject)
                UpdatePrice((ExpandoObject)value);
        }
    }
