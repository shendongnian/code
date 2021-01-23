    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {   
        base.OnModelCreating(modelBuilder); // <-- This is the important part!
        modelBuilder.Configurations.Add(new EngineeringDesignMap());
        modelBuilder.Configurations.Add(new EngineeringProjectMap());
    }
       
