    public static class UserManagerEx
    {
        public static async Task<IdentityResult> 
            ForceChangePassword<T>(
                this UserManager<T> userManager, 
                string userId,
                string newPassword) where T : class, IUser<string>
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(userId);
            var result = await userManager.ResetPasswordAsync(userId, code, newPassword);
            return result;
        }
    }
