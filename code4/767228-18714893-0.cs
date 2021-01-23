    public **int** SalesCount(string customerId)
    {
      ..
      ..
      return 500;
    }
    
    
    var resultQuery = dataContext.Customers.AsEnumerable()
                     .Where (c => c.Name == "Alugili" && SalesCount(c.CustomerId) < 100);
