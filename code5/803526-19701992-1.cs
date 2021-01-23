    public static int? PrincipalUserId(IPrincipal user)
    {
        if (!user.Identity.IsAuthenticated)
        {
            return null;
        }
        var key = string.Format("userid_{0}", user.Identity.Name);
        int userId;
        if (!SharedCacheManager.TryGetValue<int>(key, out userId))
        {
            using (UsersContext udb = new UsersContext())
            {
                userId = udb.UserProfiles
                    .Where(up => up.UserName == user.Identity.Name)
                    .First().UserId;
            }
            SharedCacheManager.SetValue<int>(key, userId);
        }
        return userId;
    }
