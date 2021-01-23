    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sir>()
            .HasRequired(s => s.DeviceA)
            .WithMany()
            .Map(m => m.MapKey("DeviceA_Id"))
            .WillCascadeOnDelete(true);
        modelBuilder.Entity<Sir>()
            .HasOptional(s => s.DeviceB)
            .WithMany()
            .Map(m => m.MapKey("DeviceB_Id"))
            .WillCascadeOnDelete(false);
        base.OnModelCreating(modelBuilder);
    }
