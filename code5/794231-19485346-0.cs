    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {   base.OnModelCreating(modelBuilder);
        modelBuilder.Configurations.Add(new EngineeringDesignMap());
        modelBuilder.Configurations.Add(new EngineeringProjectMap());
    }
       
