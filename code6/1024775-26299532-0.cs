    var data = new List<Order>()
        {
            new Order { OrderId = 1, OrderNumber = 111, OrderDate = DateTime.Now },
            new Order { OrderId = 2, OrderNumber = 222, OrderDate = DateTime.Now },
            new Order { OrderId = 3, OrderNumber = 222, OrderDate = DateTime.Now }
        }.AsQueryable();
    // <snip>...
    
    Assert.AreEqual(2, results.Count()); 
