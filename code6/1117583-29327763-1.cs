    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Map(m =>
        {
            m.ToTable("Students");
        }).Map<Kid>(m =>
        {
            m.ToTable("Kids");
            m.MapInheritedProperties();
        }).Map<Teenager>(m =>
            m.ToTable("Teenagers");
            m.MapInheritedProperties();
        });
    }
