    [WebGet]
    public IQueryable<Customers> Customers()
    {                    
        return this.CurrentDataSource.Customers.Where(x=>x.IsDeleted==false);
    }
