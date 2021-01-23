    public class SafeUserManager<TUser, TKey> : UserManager<TUser, TKey>
    {
        public override Task<bool> GetTwoFactorEnabledAsync(TKey userId)
        {
            return Store is IUserTwoFactorStore<TUser, TKey>
                ? base.GetTwoFactorEnabledAsync(userId)
                : Task.FromResult(false);
        }
    }
