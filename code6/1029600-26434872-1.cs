    void UpdatePrice(ExpandoObject expando, decimal price)
    {
        var map = (IDictionary<string, Object>)expando;
        if (map.ContainsKey("price"))
            map["price"] = price;
        foreach (var value in map.Values) 
        {
            if (value is ExpandoObject)
                UpdatePrice((ExpandoObject)value, price);
        }
    }
