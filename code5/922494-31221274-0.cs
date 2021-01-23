    public DbContext() // dbcontext constructor
                : base("name=ConnectionStringNameFromWebConfig")
    {
         this.Configuration.LazyLoadingEnabled = false;
         this.Configuration.ProxyCreationEnabled = false;
    }
