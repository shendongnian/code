    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
            public IdentityContext()
                : base("DefaultConntection", throwIfV1Schema: false)
        {
            Database.SetInitializer<IdentityContext>(null);
        }
    
        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    
    }
    
    public class AddressContext: DbContext
    {
        public AddressContext(): base("DefaultConntection")
        {
            Database.SetInitializer<AddressContext>(null);
        }
    
        public DbSet<Location> Locations { get; set; }
    }
    
    
    public class MigrationContext:IdentityDbContext<ApplicationUser>
    {
    	    public MigrationContext()
            : base("DefaultConntection", throwIfV1Schema: false)
        	{
        	}
    	
    	public DbSet<Location> Locations { get; set; }
    	//Additional DbSets here...
    }
