    public class AdminUserManager : UserManager<IdentityUser>
        public override async Task<IdentityResult> UpdateAsync(IdentityUser user)
        {
            Task<IdentityResult> result = base.UpdateAsync(user);
            try
            {
                IdentityResult identityResult = await result;
            }
            catch (Exception exception)
            {
                List<string> errors = new List<string>() { exception.Message };
                return IdentityResult.Failed(errors.ToArray());
            }
            
            return result.Result;
        }
