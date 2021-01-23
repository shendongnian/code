    public class ApplicationUser : IdentityUser
    {
    	public virtual Customer Customer { get; set; }
    	public virtual Supplier Supplier { get; set; }
    }
    
    public class Customer
    {
        [Key]
        public int Id { get; set; }
    	public virtual ApplicationUser User { get; set; }
    	public string CustomerProperty { get; set; }
    }
    
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
    	public virtual ApplicationUser User { get; set; }
    	public string SupplierProperty { get; set; }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    	public DbSet<Customer> Customers { get; set; }
    	public DbSet<Supplier> Suppliers { get; set; }
    }
    
    public class ApplicationDbInitializer
                 : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userStore = new UserStore(context);
            var userManager = new UserManager(userStore);
            var roleManager = new RoleManager(roleStore);
    
            var user = userManager.FindByEmail("customer@customer.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "customer@customer.com",
                    Email = "customer@customer.com"
    				Customer = new Customer()
    				{
    					CustomerProperty = "Additional Info"
    				}
                };
    
                userManager.Create(user, userPassword);
    			roleManager.AddUserToRole("Customer");
            }
    
            user = userManager.FindByEmail("supplier@supplier.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "supplier@supplier.com",
                    Email = "supplier@supplier.com",
    				Supplier = new Supplier()
    				{
    					IBAN = "212323424342234",
    					Relationship = "OK"
    				}
                };
    
                userManager.Create(user, userPassword);
    			roleManager.AddUserToRole("Supplier");
            }
        }
    }
