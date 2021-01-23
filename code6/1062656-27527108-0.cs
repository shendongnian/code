       public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
       {
        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
        }
       
        public DbSet<Department> Departments { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       }
