    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new EngineConfiguration());
        modelBuilder.Configurations.Add(new EngineTypeConfiguration());
    }
