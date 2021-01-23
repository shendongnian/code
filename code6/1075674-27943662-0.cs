    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, 
        ApplicationUserRole, ApplicationUserClaim>
    {
    }
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
    }
    public class ApplicationUserRole : IdentityUserRole<int>
    {
    }
