    var results = new Dictionary<string, decimal>();
    
    foreach (var order in customer.Orders)
    {
        string key = order.Pay.GetType().ToString();
        if (!results.ContainsKey(key))
        {
            results.Add(key,(decimal) 0.0);
        }
    
        results[key] += results[key] + order.Quantity*order.Price;
    }
 
