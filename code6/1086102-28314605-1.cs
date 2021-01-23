	public class User: IEntity
	{
		public Guid Id { get; protected set; }
	}
	
	public class Tenant : IEntity
	{
		public Guid Id { get; protected set; }
	}
	
	public class TenantUser
	{
		public int Id { get; set; }
		public virtual Tenant Tenant { get; set; }
		public virtual User User { get; set; }
	}
