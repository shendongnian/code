    public string GetName<T>(DbSet objectContext) where T : BaseEntity {
        IQueryable<T> myCustomer = from p in objectContext
                                   select p where p.Id = 1;
        //Get the name
        //Return the name
    }
