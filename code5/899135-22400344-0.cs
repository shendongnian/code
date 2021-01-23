    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>().HasRequired(c => c.User).WithMany().HasForeignKey(c => c.UserId);
        modelBuilder.Entity<Article>().HasRequired(c => c.Modifier).WithMany().HasForeignKey(c => c.ModifierId);
        Database.SetInitializer<Context>(null);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
