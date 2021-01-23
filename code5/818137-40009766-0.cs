    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<MyObject> MyObjects { get; set; }
    }
    
    public class MyObject
    {
        public int MyObjectId { get; set; }
    
        public string MyObjectName { get; set; }
        
        // other properties
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    
        public DbSet<MyObject> MyObjects { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<MyObject>()
                .HasRequired(c => c.ApplicationUser)
                .WithMany(t => t.MyObjects)
                .Map(m => m.MapKey("UserId"));
        }
    }
