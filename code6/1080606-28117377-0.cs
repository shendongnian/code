	public class A
	{
		public Guid ID { get; set; }
		public B B { get; set; }
	}
	public class B
	{
		public Guid ID { get; set; }
		public virtual ICollection<A> As { get; set; }
		public virtual ICollection<C> Cs { get; set; }
	}
	public class C
	{
	   public Guid ID { get; set; }
	}
    public partial class MyDbContext : DbContext
    {
        public MyDbContext(): base("name=MyConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        
    }
