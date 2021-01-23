    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.ComplexType<SomeClassSummary>();
        modelBuilder.Conventions.Add(new FunctionsConvention<MyContext>("dbo"));
    }
