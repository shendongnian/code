    public static class UserManagerEx
    {
        public static async Task<IdentityResult> ForceChangePassword<T, TUserId>(
            this UserManager<T, TUserId> userManager,
            TUserId userId,
            string newPassword)
                where T : class, IUser<TUserId>
                where TUserId : IEquatable<TUserId>
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(userId);
            var result = await userManager.ResetPasswordAsync(userId, code, newPassword);
            return result;
        }
    }
