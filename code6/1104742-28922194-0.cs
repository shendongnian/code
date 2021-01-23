        internal class DefaultMigrationSqlGenerator : SqlServerMigrationSqlGenerator
        {
            protected override void Generate(AlterTableOperation alterTableOperation)
            {
                base.Generate(alterTableOperation);
                // If the tables you want to reseed have an Id primary key...
                if (alterTableOperation.Columns.Any(c => c.Name == "Id"))
                {
                    string sqlSeedReset = string.Format("DBCC CHECKIDENT ({0}, RESEED, 1000) ", alterTableOperation.Name.Replace("dbo.", ""));
    
                    base.Generate(new SqlOperation(sqlSeedReset));
                }
            }
        }
