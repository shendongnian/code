    var customer = new Customer
    {
    //Initialization
    };
    
    Db.HashSet("customer", customer.ToHashEntries());
    Customer result = Db.HashGetAll("customer").ConvertFromRedis<Customer>();
    
    Assert.AreEqual(customer.FirstName, result.FirstName);
    Assert.AreEqual(customer.LastName, result.LastName);
    Assert.AreEqual(customer.Address1, result.Address1);
