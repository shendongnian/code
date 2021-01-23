    public static Products Clone(this Products product, DbContext context)
    {
        var set = context.Set<Products>();
        var clone = set.Create();
        clone.ProductName = product.ProductName;
        clone.SupplierID = product.SupplierID;
        clone.UnitProce = product.UnitPrice;
        // Initialize collection so you don't have to do the null check, but
        // if the property is virtual and proxy creation is enabled, it should get lazy loaded.
        clone.Suppliers = new List<Suppliers>();
        return clone;
    }
