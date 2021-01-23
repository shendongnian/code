	public class TestContext : DbContext
	{
		public TestContext()
			: base(@"Data Source=......") // On a remote SQL 2k12 instance
		{
		}
		public DbSet<TestItem> Items { get; set; }
	}
	public class TestItem
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public byte[] BinaryData { get; set; }
	}
