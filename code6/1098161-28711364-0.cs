    var orderList = context.Set<Order>
                           .Where("OrderDate >= @0", startDate)
                           .Where("OrderDate <= @0", endDate)
                           .ToList(); // ------> Relevant line <------
    var result = from o in orderList
                 join line in orderLines on o.OrderID equals line.Key
                 select new
                 {
                     o.OrderNum
                     o.OrderDate,
                     o.Customer.CustomerFullName,
                     o.DeliverAddress.State,
                     o.TotalPrice,
                     line.Value
                 };
