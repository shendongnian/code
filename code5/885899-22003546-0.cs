    var stockItems = new[] 
    { 
        new { Order = 11, Material = "M1", Quantity = 1, Desc = "Description", Batch = "x1" }, 
        new { Order = 22, Material = "M3", Quantity = 2, Desc = "apple", Batch = "x2" }, 
        new { Order = 32, Material = "M1", Quantity = 10, Desc = "banana", Batch = "x3" },
        new { Order = 11, Material = "M5", Quantity = 30, Desc = "Description", Batch = "x4" },
    };
    
    var sellItems = new[]
    {
        new { Order = 11, Material = "M1", Quantity = 12, Desc = "Description", Batch = "x1" }, 
        new { Order = 22, Material = "M3", Quantity = 21, Desc = "apple", Batch = "x2" }
    };
    
    stockItems
        .Distinct()
        .Join(
            sellItems.Distinct(), 
            stock => stock.Material.ToUpper().Trim(), 
            sell => sell.Material.ToUpper().Trim(), 
            (stock, sell) => new
            {
                Order = stock.Order,
                Material = stock.Material,
                Stock = stock.Quantity,
                Desc = stock.Desc,
                Batch = stock.Batch,
                Sell = sell.Quantity
            })
        .ToList()
        .Dump();
