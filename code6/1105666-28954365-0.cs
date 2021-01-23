    public ProductsViewModel EditProduct(int? id)
    {
        TechStoreEntities context = new TechStoreEntities();
        Product dbProduct = context.Products.Find(id);
        ProductsViewModel product = new ProductsViewModel()
        {
            // You need this line to pass the value to View
            ProductId = dbProduct.ProductId,
            Name = dbProduct.Name,
            Price = dbProduct.Price,
            Quantity = dbProduct.Quantity,
            CategoryID = dbProduct.CategoryID,
            SubcategoryID = dbProduct.SubcategoryID,
            IsNew = dbProduct.IsNew
        };
        return product;
    }
