    var project = group.Project(x => new OrderSummary
    {
         Month = x.MonthAndProduct.Month, 
         Product = x.MonthAndProduct.Product, 
         TotalSales = x.TotalSales
    });
