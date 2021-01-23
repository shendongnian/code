    // GET api/Sales
    public IQueryable<FactSale> GetFactSales()
    {
        return db.FactSales
                 .Include(x => x.DimCategory)
                 .Include(x => x.DimDate)
                 // ...and more if you need so...
                 .AsQueryable();
    }
