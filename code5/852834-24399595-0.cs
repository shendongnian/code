        public class WebPortalDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebPortalDbContext()
            : base("IdentityConnection")
        {
        }
        public static WebPortalDbContext Create()
        {
            return new WebPortalDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>()
                .Property(c => c.Name).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>().ToTable("AspNetUsers")//I have to declare the table name, otherwise IdentityUser will be created
                .Property(c => c.UserName).HasMaxLength(128).IsRequired();
        }
    }
 
