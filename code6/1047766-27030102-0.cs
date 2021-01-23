	public class OrderContext : DbContext
	{
		private readonly string _tableName;
		public OrderContext(string tableName)
			: base("name=OrderContext")
		{
			_tableName = tableName;
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>().ToTable(_tableName);
			base.OnModelCreating(modelBuilder);
		}
		public ICollection<Order> Orders { get; set; }
	}
