    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    	public ApplicationDbContext()
    		: base("DefaultConnection", throwIfV1Schema: false)
    	{
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder); // This needs to go before the other rules!
    
    		modelBuilder.Entity<ApplicationUser>().ToTable("User");
    		modelBuilder.Entity<IdentityRole>().ToTable("Role");
    		modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
    		modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
    		modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
    	}
    
    	public static ApplicationDbContext Create()
    	{
    		return new ApplicationDbContext();
    	}
    }
