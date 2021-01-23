    public ApplicationDBContext()
        : base("DefaultConnection")
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDBContext, IBCF.Core.Migrations.Configuration>());
    }
