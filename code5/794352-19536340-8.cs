    // Update TenantDataCtx
    var tenantDataMigrationsConfiguration = new DbMigrationsConfiguration<TenantDataContext.TenantDataCtx>();
    tenantDataMigrationsConfiguration.AutomaticMigrationsEnabled = false;
    tenantDataMigrationsConfiguration.SetSqlGenerator("System.Data.SqlClient", new SqlServerSchemaAwareMigrationSqlGenerator(schemaName));
    tenantDataMigrationsConfiguration.SetHistoryContextFactory("System.Data.SqlClient", (existingConnection, defaultSchema) => new HistoryContext(existingConnection, schemaName));
    tenantDataMigrationsConfiguration.TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo(connectionString, "System.Data.SqlClient");
    tenantDataMigrationsConfiguration.MigrationsAssembly = typeof(TenantDataContext.TenantDataCtx).Assembly;
    tenantDataMigrationsConfiguration.MigrationsNamespace = "TenantDataContext.Migrations.TenantData";
    
    DbMigrator tenantDataCtxMigrator = new DbMigrator(tenantDataMigrationsConfiguration);
    tenantDataCtxMigrator.Update();
