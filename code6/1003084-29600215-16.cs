    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        // Any additional columns from your existing users table will appear here.
    }
    public class Role : IdentityRole<int, UserRole>
    {
    }
    public class UserClaim : IdentityUserClaim<int>
    {
    }
    public class UserLogin : IdentityUserLogin<int>
    {
    }
    public class UserRole : IdentityUserRole<int>
    {
    }
    
