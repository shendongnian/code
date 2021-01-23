    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser, string> userManager, IAuthenticationManager authenticationManager) 
            : base(userManager, authenticationManager)
        {
        }
        public async Task<SignInStatus> SignInAsync(string userName, string password, bool rememberMe)
        {
            var user = await UserManager.FindByNameAsync(userName);
            if (user == null) return SignInStatus.Failure;
            if (await UserManager.IsLockedOutAsync(user.Id)) return SignInStatus.LockedOut;
            if (!await UserManager.CheckPasswordAsync(user, password))
            {
                await UserManager.AccessFailedAsync(user.Id);
                if (await UserManager.IsLockedOutAsync(user.Id))
                {
                    return SignInStatus.LockedOut;
                }
                return SignInStatus.Failure;
            }
            if (await UserManager.GetTwoFactorEnabledAsync(user.Id))
            {
                if (!(await UserManager.IsEmailConfirmedAsync(user.Id) || await UserManager.IsPhoneNumberConfirmedAsync(user.Id)))
                {
                    return SignInStatus.RequiresVerification;
                }
            }
            await base.SignInAsync(user, rememberMe, false);
            return SignInStatus.Success;
        }
    }
