    var project = group.Project(x => new OrderSummary
    {
         Month = x.Key.Month, 
         Product = x.Key.Product, 
         TotalSales = x.TotalSales
    });
