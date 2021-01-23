	public void EditLine(Product product, int quantity)
    {
        CartLine line = lineCollection
        .Where(p => p.Product.ProductID == product.ProductID)
        .FirstOrDefault();
        if (line != null)
        {
            line.Quantity += quantity;
        }
    }
