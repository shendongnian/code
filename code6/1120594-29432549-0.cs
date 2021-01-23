    public IEnumerable<User> ReadUsers()
    {
        ctx.Configuration.ProxyCreationEnabled = false;
        IEnumerable<User> users = ctx.Users.ToList();
        return users;
    }
