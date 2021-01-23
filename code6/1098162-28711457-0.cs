    IDictionary<int, string> orderLines = new Dictionary<int, string>();
   
    // Add a dummy item
    orderLines[1234] = "Hello, this, is, a, test";
    // Get your combined view
    // Assuming you have an order with 1234 as the ID, this should work
    var result = from o in orders
                 select new
                 {
                     o.OrderNum
                     o.OrderDate,
                     o.Customer.CustomerFullName,
                     o.DeliverAddress.State,
                     o.TotalPrice,
                     orderLines[o.OrderID]
                 }
