	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;
	public class A
	{
		public int Id { get; set; }
		public E P { get; set; } // #1
		public enum E { }
	}
	public class B
	{
		public int Id { get; set; }
		public E P { get; set; } // #2
		public enum E { }
	}
	static class Program
	{
		static void Main()
		{
			var modelBuilder = new DbModelBuilder(DbModelBuilderVersion.Latest);
			modelBuilder.Entity<A>();
			modelBuilder.Entity<B>();
			var model = modelBuilder.Build(new DbProviderInfo("System.Data.SqlClient", "2012"));
		}
	}
