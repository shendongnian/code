    public class AplicationUserManager : UserManager<....> 
    {
        public async Task<IdentityResult> ChangePasswordAsync(TKey userId, string newPassword) 
        {
            var store = this.Store as IUserPasswordStore;
            if(store==null) 
                 throw new InvalidOperationException("Current UserStore doesn't implement IUserPasswordStore");
            var newPasswordHash = ...; // get your password Hash here
            await store.SetPasswordHashAsync(userId, newPasswordHash);
            return Task.FromResult<IdentityResult>(new IdentityResult { Succeeded = true } );
        }
    }
