    Customer[] CustomerList;
    int CustomerID;
    var x = CustomerList
       .Where(r => r.CustomerID == CustomerID)
       .Select(r => new { 
          OrderCount = r.Orders.Count(), 
          OrderPageList = r.Orders.Skip(500).Take(100).ToArray() });
