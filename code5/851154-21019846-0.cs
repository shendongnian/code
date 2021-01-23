    List<Product> basket = new List<Product>();
    public void AddOrUpdateProducts(Product p, int quantity)
    {
        // Update
        foreach (Product product in basket)
        {
            if (product.Id == p.Id)
            {
                product.Quantity += quantity;
                return;
            }
        }
        // Add
        basket.Add(p, quantity);
    }
    public void AddProduct(string productName, decimal latestPrice)
    {
        AddProduct(productName, latestPrice, 1);
    }
