    public static class IdentityApplicationUserExtension
    {
        public static User GetApplicationUser(this IIdentity identity)
        {
            var manager = new UserManager<User>(new UserStore<User>(new MyDbContext()));
            return manager.FindById<User>(identity.GetUserId());
        }
    }
