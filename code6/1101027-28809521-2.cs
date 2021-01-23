    public void InsertProduct(Product item)
    {
        // Calling this code before the context is aware of the Child
        // objects will cause the context to attach the Child objects to the     
        // context and then set the state.
        // CustomerContext.Entry(childitem).State = EntityState.Unchanged
        CustomerContext.Entry(item.ChildObject).State = EntityState.Modified;
        CustomerContext.Entry(item).State = EntityState.Added;
        CustomerContext.Set<Product>().Add(item);
    }
