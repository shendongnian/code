    public class Customer
    {
        public int CustomerID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    
    public class ApplicationUser : IdentityUser
    {
        public virtual Customer Customer { get; set; }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        
        public DbSet<Customer> Customers { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            // one-to-zero or one relationship between ApplicationUser and Customer
            // UserId column in Customers table will be foreign key
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(m => m.Customer)
                .WithRequired(m => m.ApplicationUser)
                .Map(p => p.MapKey("UserId"));
        }
    
    }
