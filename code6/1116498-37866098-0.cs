    public class AppUserManager : UserManager<AppUser, int>
    {
        .
        // standard methods...
        .
    
        public async Task<IdentityResult> ChangePasswordAsync(AppUser user, string newPassword)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
    
            var store = this.Store as IUserPasswordStore<AppUser, int>;
            if (store == null)
            {
                var errors = new string[] { "Current UserStore doesn't implement IUserPasswordStore" };
                return IdentityResult.Failed(errors);
            }
    
            var newPasswordHash = this.PasswordHasher.HashPassword(newPassword);
            await store.SetPasswordHashAsync(user, newPasswordHash);
            await store.UpdateAsync(user);
            return IdentityResult.Success;
        }
    }
