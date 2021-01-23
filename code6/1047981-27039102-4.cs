    public partial class OwnContext: DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Group> Groups { get; set; }
       public DbSet<Permission> Permissions { get; set; }
       public DbSet<UserGroup> UserGroups { get; set; }
       public DbSet<PermissionGroup> PermissionGroups { get; set; }
    }
