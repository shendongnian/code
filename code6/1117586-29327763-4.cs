    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kid>().Map(m =>
        {
            m.ToTable("Kids");
            m.MapInheritedProperties();
        });
        modelBuilder.Entity<Teenager>().Map(m =>
        {
            m.ToTable("Teenagers");
            m.MapInheritedProperties();
        });
    }
