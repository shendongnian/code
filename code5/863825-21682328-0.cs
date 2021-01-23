    var baseCust = db.Customers.FirstOrDefault(x => x.Id == someId);
    if(baseCust is CustTypeA)
    {
       // Access extended properties and Legacy tables (via lazy loading)
       var custA = (CustTypeA)baseCust;
       custA.SomeExtendedProperty = blah;
       var oldCompletedOrders = custA.Orders.Where(x => x.Completed).ToList();
       //etc
