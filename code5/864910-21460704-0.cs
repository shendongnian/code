    public class SecurityContext : IdentityDbContext<ApplicationUser>
    {
        public SecurityContext()
            : base("SimpleSecurityConnection")
        {
        }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<OperationsToRoles> OperationsToRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ResourceConfiguration());
            modelBuilder.Configurations.Add(new OperationsToRolesConfiguration());
        }
    }
