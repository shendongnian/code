    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
         modelBuilder.Entity<Business>()
          .HasOptional(a => a.OpeningHours)
          .WithOptionalDependent()
          .WillCascadeOnDelete(true);
        base.OnModelCreating(modelBuilder);
    }
