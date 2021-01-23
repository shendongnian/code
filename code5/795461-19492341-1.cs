    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Configurations.Add(new UserProfileConfiguration());
    }
