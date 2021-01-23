    public class MyUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserSecurityStampStore<ApplicationUser>
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new ApplicationDbContext());
        public MyUserStore()
        {
        }
        public Task CreateAsync(ApplicationUser user)
        {
            var context = userStore.Context as ApplicationDbContext;
            context.Users.Add(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }
        public Task DeleteAsync(ApplicationUser user)
        {
            var context = userStore.Context as ApplicationDbContext;
            context.Users.Remove(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }
        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            var context = userStore.Context as ApplicationDbContext;
            return context.Users.Where(u => u.Id.ToLower() == userId.ToLower()).FirstOrDefaultAsync();
        }
        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var context = userStore.Context as ApplicationDbContext;
            return context.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }
        public Task UpdateAsync(ApplicationUser user)
        {
            var context = userStore.Context as ApplicationDbContext;
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChangesAsync();
        }
        public void Dispose()
        {
            userStore.Dispose();
        }
       
        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetPasswordHashAsync(identityUser);
            SetApplicationUser(user, identityUser);
            return task;
        }
        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.HasPasswordAsync(identityUser);
            SetApplicationUser(user, identityUser);
            return task;
        }
        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetPasswordHashAsync(identityUser, passwordHash);
            SetApplicationUser(user, identityUser);
            return task;
        }
        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.GetSecurityStampAsync(identityUser);
            SetApplicationUser(user, identityUser);
            return task;
        }
        public Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            var identityUser = ToIdentityUser(user);
            var task = userStore.SetSecurityStampAsync(identityUser, stamp);
            SetApplicationUser(user, identityUser);
            return task;
        }
        private static void SetApplicationUser(ApplicationUser user, IdentityUser identityUser)
        {
            user.PasswordHash = identityUser.PasswordHash;
            user.SecurityStamp = identityUser.SecurityStamp;
            user.Id = identityUser.Id;
            user.UserName = identityUser.UserName;
        }
        private IdentityUser ToIdentityUser(ApplicationUser user)
        {
            return new IdentityUser
            {
                Id = user.Id,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserName = user.UserName
            };
        }
    }
