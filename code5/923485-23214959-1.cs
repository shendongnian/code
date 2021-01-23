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
          yield return new MigrationStatement { Sql = "set transaction isolation level read committed" };
          foreach (var statement in base.Generate(migrationOperations, providerManifestToken))
            yield return statement;
        }
      }
    }
