    var config = new MyDatabaseMigrationsConfiguration();
    var migrator = new System.Data.Entity.Migrations.Infrastructure.MigratorLoggingDecorator(new System.Data.Entity.Migrations.DbMigrator(config), new MyCommonMigrationsLogger());
    if (migrator.GetPendingMigrations().Any())
    {
      migrator.Update();
    }
