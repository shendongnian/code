    // same namespace as existing class
    namespace Dal
    {
        // Same name as existing class
        public partial class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
        {
            // This can probably be left blank
        }
    }
