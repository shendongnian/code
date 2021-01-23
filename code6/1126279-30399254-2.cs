        public class AppSignInManager : SignInManager<AppUser, string>
        {
         ....
        public virtual async Task<SignInStatus> PasswordSignInViaEmailAsync(string userEmail, string password, bool isPersistent, bool shouldLockout)
        {
            var userManager = ((AppUserManager) UserManager);
            if (userManager == null)
            {
                return SignInStatus.Failure;
            }
            var user = await UserManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return SignInStatus.Failure;
            }
            if (await UserManager.IsLockedOutAsync(user.Id))
            {
                return SignInStatus.LockedOut;
            }
            if (await UserManager.CheckPasswordAsync(user, password))
            {
                await UserManager.ResetAccessFailedCountAsync(user.Id);
                await SignInAsync(user, isPersistent, false);
                return SignInStatus.Success;
            }
            if (shouldLockout)
            {
                // If lockout is requested, increment access failed count which might lock out the user
                await UserManager.AccessFailedAsync(user.Id);
                if (await UserManager.IsLockedOutAsync(user.Id))
                {
                    return SignInStatus.LockedOut;
                }
            }
            return SignInStatus.Failure;
        }
