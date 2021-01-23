	public class MyEntityMap : EntityTypeConfiguration<MyEntity>
	{
		public const string TableName = "MyEntity";
		public MyEntityMap()
		{					
			ToTable(TableName);
			Property(t => t.Id);
		}
	}
