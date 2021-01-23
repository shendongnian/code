    [SetUp]
    public virtual void SetupInitialData()
    {
        var data = InitializeData();
        Context = new FmsDbContext();
        if (data != null)
        {
            Database.SetInitializer(new TestDataInitializer(data));
        }
        Context.Database.Initialize(true);
    }
