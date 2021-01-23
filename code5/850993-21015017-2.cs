    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new SomeExistingEntityClass1Config());
        modelBuilder.Configurations.Add(new SomeExistingEntityClass2Config());
        ....
        modelBuilder.Configurations.Add(new MyEntityClassConfig()); // <-- Add this
    }
