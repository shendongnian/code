    if(result == null)
    {
      result = new Order
      {
        Customer = context.Customers.Single(x => x.Id == 5);
        ...
      };
      context.Orders.Add(result);
      context.SaveChanges();
    }
