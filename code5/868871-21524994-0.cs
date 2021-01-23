    private DbMigrationsConfiguration configuration;
    public void InitializeDatabase(C context) {
        context.Database.Delete();
        context.Database.Create();
        var migrator = new DbMigrator(configuration);
        migrator.Update();
    }
