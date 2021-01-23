	public class MyEntityMap : EntityTypeConfiguration<MyEntity>
	{
		public const string TableName = "MyEntity";
		public ActionMap()
		{					
			ToTable(TableName);
			Property(t => t.Id);
		}
	}
