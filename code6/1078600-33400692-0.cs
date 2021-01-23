    class SqlGenerator : MySql.Data.Entity.MySqlMigrationSqlGenerator
    {
        public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            IEnumerable < MigrationStatement > res =  base.Generate(migrationOperations, providerManifestToken);
            foreach(MigrationStatement ms in res)
            {
                ms.Sql = ms.Sql.Replace("dbo.","");
            }
            return res;
        }
    }
    (...)
    SetSqlGenerator("MySql.Data.MySqlClient", new SqlGenerator());
