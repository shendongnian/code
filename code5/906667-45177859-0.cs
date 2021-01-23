     public static ClaimsIdentity CreateIdentity<TUser, TKey>(this UserManager<TUser, TKey> manager, TUser user,
            string authenticationType)
            where TKey : IEquatable<TKey>
            where TUser : class, IUser<TKey>
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }
            return AsyncHelper.RunSync(() => manager.CreateIdentityAsync(user, authenticationType));
        }
