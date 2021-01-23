    var customers = new[]{
        new Customer { Name = "cust_a" },
        new Customer { Name = "cust_b" },
        new Customer { Name = "cust_c" }
    };
    context.Customers.AddOrUpdate(r => r.Name, customers[0], customers[1], customers[2]);
    context.SaveChanges()
