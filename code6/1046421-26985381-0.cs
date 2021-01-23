    public string GetName<T>(T caller, System.Data.Entity.DbSet objectContext)
    {
        IQueryable<T> myEntity = from p in objectContext
                                 select p where p.Id=1; //get customer name
    }
