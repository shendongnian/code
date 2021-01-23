    public class SecurityDbContext : DbContextBase<SecurityDbContext>
    {
        
        public DbSet<Permission> Permissions { get; set;}
        // or use IDbSet
        public IDbSet<CustomRole> CustomRoles { get; set;}
        // other stuff
    }
