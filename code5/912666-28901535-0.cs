    public class NonClusteredPrimaryKeySqlMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        public override IEnumerable<System.Data.Entity.Migrations.Sql.MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            var primaries = migrationOperations.OfType<CreateTableOperation>().Where(x => x.PrimaryKey.IsClustered).Select(x => x.PrimaryKey).ToList();
            var indexes = migrationOperations.OfType<CreateIndexOperation>().Where(x => x.IsClustered).ToList();
            foreach (var index in indexes)
            {
                var primary = primaries.Where(x => x.Table == index.Table).SingleOrDefault();
                if (primary != null)
                {
                    primary.IsClustered = false;
                }
            }
            return base.Generate(migrationOperations, providerManifestToken);
        }
    }
    public class EFCustomConfiguration : DbConfiguration
    {
        public EFCustomConfiguration()
        {
            SetMigrationSqlGenerator("System.Data.SqlClient", () => new NonClusteredPrimaryKeySqlMigrationSqlGenerator());
        }
    }
