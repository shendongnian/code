    List<FullCustomerInfo> rows = db.Select<FullCustomerInfo>(  // Map results to FullCustomerInfo POCO
      db.From<Customer>()                                       // Create typed Customer SqlExpression
        .LeftJoin<CustomerAddress>()                            // Implicit left join with base table
        .Join<Customer, Order>((c,o) => c.Id == o.CustomerId)   // Explicit join and condition
        .Where(c => c.Name == "Customer 1")                     // Implicit condition on base table
        .And<Order>(o => o.Cost < 2)                            // Explicit condition on joined Table
        .Or<Customer,Order>((c,o) => c.Name == o.LineItem));    // Explicit condition with joined Tables
