    public static void RunMigration(this DbContext context, DbMigration migration)
    {            
        var prop = migration.GetType().GetProperty("Operations", BindingFlags.NonPublic | BindingFlags.Instance);
        if (prop != null)
        {
            IEnumerable<MigrationOperation> operations = prop.GetValue(migration) as IEnumerable<MigrationOperation>;
            var generator = new SqlServerMigrationSqlGenerator();
            var statements = generator.Generate(operations, "2008");
            foreach (MigrationStatement item in statements)
                context.Database.ExecuteSqlCommand(item.Sql);
        }
    }
