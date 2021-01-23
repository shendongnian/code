    internal class DiscriminatorServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        const string DiscriminatorColumnName = "Discriminator";
        protected override void Generate(CreateTableOperation op)
        {
            base.Generate(op);
            if (op.Columns.Any(x => x.Name == DiscriminatorColumnName))
            {
                if (op.PrimaryKey != null && op.PrimaryKey.Columns.Any())
                {
                    CreateDiscriminatorIndex(op.Name, true, op.PrimaryKey.Columns.ToArray());
                }
                else
                {
                    CreateDiscriminatorIndex(op.Name);
                }
            }
        }
        private void CreateDiscriminatorIndex(string tableName, bool isUnique = false, params string[] columns)
        {
            var cols = "[Discriminator]";
            if (columns.Length > 0)
            {
                cols += ", " + string.Join(", ", columns.Select(x => "[" + x + "]"));
            }
            var unique = isUnique ? "UNIQUE" : "";
            using (var writer = Writer())
            {
                var str = $@"
    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Discriminator' AND object_id = OBJECT_ID(N'{tableName}'))
    EXECUTE('CREATE {unique} NONCLUSTERED INDEX [IX_Discriminator] ON {tableName} ({cols})')";
                writer.WriteLine(str);
                Statement(writer);
            }
        }
    }
