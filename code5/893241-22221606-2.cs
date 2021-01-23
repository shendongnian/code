    public Task CreateAsync(TUser user)
    {
        _session.Save(user);
        return Task.FromResult<object>(null);
    }
