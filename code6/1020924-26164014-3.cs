    public class YourDataContext : IdentityDbContext<User, Role, string,   UserLogin, UserRole, UserClaim>
    {
        // Your DbSet items
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
    
            modelBuilder.Entity<User>().Property(r => r.Id);
            modelBuilder.Entity<UserClaim>().Property(r => r.Id);
            modelBuilder.Entity<Role>().Property(r => r.Id);
           //Add your new properties of Role table in here.
    
        }
    }
