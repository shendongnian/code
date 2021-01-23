     internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedUtcColumn(addColumnOperation.Column);
            base.Generate(addColumnOperation);
        }
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedUtcColumn(createTableOperation.Columns);
            base.Generate(createTableOperation);
        }
        private static void SetCreatedUtcColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetCreatedUtcColumn(columnModel);
            }
        }
        private static void SetCreatedUtcColumn(PropertyModel column)
        {
            if (column.Name == "CreatedUtc")
            {
                column.DefaultValueSql = "GETUTCDATE()";
            }
        }
    }
