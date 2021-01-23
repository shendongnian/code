Consider Overriding the OnModelCreating method inside your DbContext
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext,Configuration>());
        base.OnModelCreating(modelBuilder);
    }
