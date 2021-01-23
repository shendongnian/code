    public void Order.AddOrderLine(ISomeRepository repo, Product product)
    {
        if(!repo.ProductExists(product))
             throw new AddProductException
    
        OrderLines.Add(new OrderLine(product));
    }
    // call it like
    Order.AddOrderLine(someRepository, product);
