    public Task CreateAsync(TUser user)
    {
        Action action = () => _session.Save(user);
        return Task.Run(action);
    }
