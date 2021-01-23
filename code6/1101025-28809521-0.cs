    public void InsertProduct(Product item)
    {
        CustomerContext.Entry(item.ChildObject).State = EntityState.Modified;
        CustomerContext.Entry(item).State = EntityState.Added;
        CustomerContext.Set<Product>().Add(item);
    }
