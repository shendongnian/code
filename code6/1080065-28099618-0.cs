    public class ApplicationRole : IdentityRole
    {
          ...
          public ICollection<ApiController> Controllers { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
          public ApplicationDbContext(): base("DefaultConnection") {}
    }
    public class ApiController
    {
            [Key]
            public int ApiControllerId { get; set; }
            public ICollection<ApplicationRole> Roles { get; set; }
