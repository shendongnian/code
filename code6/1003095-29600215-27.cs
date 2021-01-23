    public partial class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        // Any additional columns from your existing users table will appear here.
    }
    public partial class Role : IdentityRole<int, UserRole>
    {
    }
    public partial class UserClaim : IdentityUserClaim<int>
    {
    }
    public partial class UserLogin : IdentityUserLogin<int>
    {
    }
    public partial class UserRole : IdentityUserRole<int>
    {
    }
