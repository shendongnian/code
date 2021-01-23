	public class TestContext : DbContext
	{
		public TestContext()
			: base(@"Server=(localdb)\\v11.0;Integrated Security=true;Initial Catalog=BENCH") // Local instance
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
