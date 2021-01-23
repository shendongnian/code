    public class User : IdentityUser
        {
            public string PasswordOld { get; set; }
            public DateTime DateCreated { get; set; }
    
            public bool Activated { get; set; }
    
            public bool UserRole { get; set; }
    
        }
    
    public class ApplicationDbContext : IdentityDbContext<User>
        {
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }
    
            protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<IdentityUser>()
                    .ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("User_Id");
                modelBuilder.Entity<User>()
                    .ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("User_Id");
            }
        }
