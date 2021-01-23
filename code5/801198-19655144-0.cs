    public partial class EFContextContainer : DbContext 
    enter code here
    public EFContextContainer ()
            : base("name=EFContextContainer")
        {
        }
     
    public DbSet<IdentityUser> IdentityUsers { get;set; } 
