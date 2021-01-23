    interface StoreInventory
    {
        IEnumerable<Product> AvailableProducts { get; }
        Product PickProduct(guid productId); // This doesn't have to be an Id, it could be some other key or a specification.
    }
    void Order.AddOrderLine(StoreInventory inventory, Product product)
    {
        if (!inventory.Products.Contains(product))
            throw new AddProductException();
        var item = inventory.Pick(product);
        OrderLines.Add(new OrderLine(item);
    }
