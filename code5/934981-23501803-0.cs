    // GET api/Products
    public IQueryable<ProductList> GetProduct() //Change return type
    {
        // return db.ITEM_MASTER;
    
        return db.ITEM_MASTER.Select(x => new ProductList { ItemCode = x.IM_ITEM_CODE });
    }
