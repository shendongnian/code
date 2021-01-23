    public class CustomMigrationCodeGenerator : CSharpMigrationCodeGenerator
    {
        protected override void Generate(CreateTableOperation createTableOperation, IndentedTextWriter writer)
        {
            if (createTableOperation.Columns.Any(x => x.Name == "Index") &&
                 createTableOperation.Columns.Any(x => x.Name == "Id"))
            {
                if (createTableOperation.PrimaryKey != null)
                {
                    createTableOperation.PrimaryKey.IsClustered = false;
                }
            }
            base.Generate(createTableOperation, writer);
        }
    }
