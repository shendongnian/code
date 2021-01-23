    public class Identity
    {
        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <returns>UserManager&lt;User, System.Int32&gt;.</returns>
        public static UserManager<User, int> GetUserManager()
        {
            var store = new UserStore<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(new DataContext());
            var userManager = new UserManager<User, int>(store);
            return userManager;
        }
    }
