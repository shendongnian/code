	public class NonClusteredPrimaryKeySqlMigrationSqlGenerator : SqlServerMigrationSqlGenerator
	{
		protected override void Generate(System.Data.Entity.Migrations.Model.AddPrimaryKeyOperation addPrimaryKeyOperation)
		{
			addPrimaryKeyOperation.IsClustered = false;
			base.Generate(addPrimaryKeyOperation);
		}
		protected override void Generate(System.Data.Entity.Migrations.Model.CreateTableOperation createTableOperation)
		{
			createTableOperation.PrimaryKey.IsClustered = false;
			base.Generate(createTableOperation);
		}
		protected override void Generate(System.Data.Entity.Migrations.Model.MoveTableOperation moveTableOperation)
		{
			moveTableOperation.CreateTableOperation.PrimaryKey.IsClustered = false;
			base.Generate(moveTableOperation);
		}
