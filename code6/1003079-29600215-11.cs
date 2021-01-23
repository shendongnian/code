    // same namespace as existing class
    namespace Dal
    {
        // Same name as existing class
        public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
        {
            // This can probably be left blank
        }
    }
