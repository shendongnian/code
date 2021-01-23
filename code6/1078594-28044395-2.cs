    // available products is your output
    Dictionary<string, List<Products>> availableProducts = new Dictionary<string, List<Products>>();
    var serializer = new JavaScriptSerializer();
    dynamic result = serializer.Deserialize<dynamic>(json);
    KeyValuePair<string, object> temp = ((Dictionary<string, object>)result["success"]).First();
    var customerNumber = temp.Key;
    var entries = (Dictionary<string, object>)temp.Value;
    foreach (var kvp in entries)
    {
        var products = new List<Products>();
        IEnumerable collection = (IEnumerable)kvp.Value;
        foreach (dynamic item in collection)
        {
            products.Add(new Products
            {
                ProductName = item.Key,
                Units = item.Value
            });
        }
        availableProducts[kvp.Key] = products;
    }
