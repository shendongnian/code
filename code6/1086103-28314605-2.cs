	public class UnitOfWork : DbContext
	{
		public IDbSet<User> Users { get; set; }
		public IDbSet<Tenant> Tenants { get; set; }
		public IDbSet<TenantUser> TenantUsers { get; set; }
	}
	context.TenantUsers.Include(e => e.Tenant).Include(e => e.User);
