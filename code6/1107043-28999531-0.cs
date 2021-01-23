    public Box(Func<Owned<DbContext>> factory)
    {
        using (Owned<DbContext> ownedDbContext = factory())
        {
            // instance1
        }
        using (Owned<DbContext> ownedDbContext = factory())
        {
            // instance2 
        }
    }
