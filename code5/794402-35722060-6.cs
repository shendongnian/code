        public class ApplicationDbContext : IdentityDbContext
        {    
            public ApplicationDbContext(): base("DefaultConnection")
            {
            }
        
            protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<IdentityUser>().ToTable("user");
                modelBuilder.Entity<ApplicationUser>().ToTable("user");
        
                modelBuilder.Entity<IdentityRole>().ToTable("role");
                modelBuilder.Entity<IdentityUserRole>().ToTable("userrole");
                modelBuilder.Entity<IdentityUserClaim>().ToTable("userclaim");
                modelBuilder.Entity<IdentityUserLogin>().ToTable("userlogin");
            }
        }
