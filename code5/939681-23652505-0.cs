    public MyEntitiesContext() : base("name=MyEntitiesContext", "MyEntitiesContext")
    {
    this.ContextOptions.LazyLoadingEnabled = false;
    OnContextCreated();
    }
