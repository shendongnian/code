    using (var context = new MyContext())
    {
        context.Configuration.ProxyCreationEnabled = false;
        var orders = context.Order.Include("OrderProduct")
                                  .Include("OrderProduct.ProductVariant")
                                  .Where(some query)
                                  .ToList();
    }
