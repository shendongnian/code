    public StoreMap()
    {
        Id(x => x.Id);
        HasOne(x => x.Staff).Cascade.All();
    }
    
    public EmployeeMap()
    {
        Id(x => x.Id).GeneratedBy.Foreign("Store");
        HasOne(x => x.Store).Constrained();
    }
