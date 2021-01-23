    ...
    group p by p.Category into prices
    select new 
    {
        price = prices.Average(p => p.UnitPrice), 
        name = prices.Key.CategoryName 
    }
