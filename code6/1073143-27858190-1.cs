    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Maintenance>().Property(a => a.GroupID 
                              ).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<Maintenance>().Property(a => a.SerialNo 
                              ).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
