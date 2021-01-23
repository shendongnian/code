		public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>
		{
			protected override void Seed(MyDbContext context)
			{
				context.Database.ExecuteSqlCommand("DROP TABLE MyTable");
				context.Database.ExecuteSqlCommand("CREATE TABLE MyTable (bla bla bla)  WITH (MEMORY_OPTIMIZED=ON)");
			}
		}
