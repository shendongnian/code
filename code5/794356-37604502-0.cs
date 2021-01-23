    public class SqlServerSchemaAwareMigrationSqlGenerator:SqlServerMigrationSqlGenerator
    {
        private string _schema;
        public accountMigrationSqlGenerator(string schema)
        {
            _schema = schema;
        }
        protected override string Name(string name)
        {
            int p = name.IndexOf('.');
            if(p>0)
            {
                name = name.Substring(p + 1);
            }
            return $"[{_schema}].[{name}]";
        }
    }
