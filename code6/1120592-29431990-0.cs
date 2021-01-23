    public IEnumerable<User> ReadUsers()
    {
        ctx.Configuration.LazyLoadingEnabled = false;
        IEnumerable<User> users = ctx.Users.ToList();
        return users;
    }
