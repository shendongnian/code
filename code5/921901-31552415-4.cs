    public class OurMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddPrimaryKeyOperation addPrimaryKeyOperation)
        {
            if (addPrimaryKeyOperation == null) throw new ArgumentNullException("addPrimaryKeyOperation");
            if (!addPrimaryKeyOperation.Table.Contains("__MigrationHistory"))
                addPrimaryKeyOperation.IsClustered = false;
            base.Generate(addPrimaryKeyOperation);
        }
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            if (createTableOperation == null) throw new ArgumentNullException("createTableOperation");
            if (!createTableOperation.Name.Contains("__MigrationHistory"))
                createTableOperation.PrimaryKey.IsClustered = false;
            base.Generate(createTableOperation);
        }
        protected override void Generate(MoveTableOperation moveTableOperation)
        {
            if (moveTableOperation == null) throw new ArgumentNullException("moveTableOperation");
            if (!moveTableOperation.CreateTableOperation.Name.Contains("__MigrationHistory")) moveTableOperation.CreateTableOperation.PrimaryKey.IsClustered = false;
            base.Generate(moveTableOperation);
        }
    }
