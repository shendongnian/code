    public class AplicationUserManager : UserManager<....> 
    {
        public async Task<IdentityResult> ChangePasswordAsync(TKey userId, string newPassword) 
        {
            var store = this.Store as IUserPasswordStore;
            if(store==null) 
            {
                var errors = new string[] 
                { 
                    "Current UserStore doesn't implement IUserPasswordStore"
                };
                return Task.FromResult<IdentityResult>(new IdentityResult(errors) { Succeeded = false });
            }
            var newPasswordHash = this.PasswordHasher.HashPassword(newPassword);
            await store.SetPasswordHashAsync(userId, newPasswordHash);
            return Task.FromResult<IdentityResult>(IdentityResult.Success);
        }
    }
