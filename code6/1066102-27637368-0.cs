    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Entity<Business>()
                .WithMany(e=>e.OpeningHours)
                .WillCascadeOnDelete(true);
        base.OnModelCreating(modelBuilder);
    }
