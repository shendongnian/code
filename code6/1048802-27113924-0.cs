    public class Person
    {
    	public int ID { get; set; }
    
    	public string Name { get; set; }
    
    	public IList<Account> Accounts { get; set; }
    }
    
    public class Account
    {
    	public int ID { get; set; }
    
    	public string Name { get; set; }
    
    	public IList<Person> Persons { get; set; }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    	public DbSet<Account> AccountSet { get; set; }
    
    	public DbSet<Person> PersonSet { get; set; }
    
    	public ApplicationDbContext()
    		: base("DefaultConnection")
    	{
    		this.Database.Log = (msg) => { Debug.Write(msg); };
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    
    		modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    
    		modelBuilder.Entity<Account>().HasKey(x => x.ID);
    		modelBuilder.Entity<Person>().HasKey(x => x.ID);
    
    		modelBuilder.Entity<Account>()
    			.HasMany(a => a.Persons)
    			.WithMany()
    			.Map(w =>
    			{
    				w.MapLeftKey("AccountId");
    				w.MapRightKey("PersonId");
    				w.ToTable("AccountsToPersons");
    			});
    	}
    }
