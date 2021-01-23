    internal sealed class Configuration : DbMigrationsConfiguration<SupplierEntities>
    {
      public Configuration()
      {
        SetSqlGenerator("System.Data.SqlClient", new SqlMigrator());
      }
      private class SqlMigrator : SqlServerMigrationSqlGenerator
      {
        public override IEnumerable<MigrationStatement> Generate(
          IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
          var statements = new List<MigrationStatement>
          {
            new MigrationStatement {Sql = "set transaction isolation level read committed"}
          };
          statements.AddRange(base.Generate(migrationOperations, providerManifestToken));
          return statements;
        }
      }
    }
