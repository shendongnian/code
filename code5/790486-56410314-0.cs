    public IClientSessionHandle StartSession()
    {
        return _client.StartSession(new ClientSessionOptions());
    }
    public async Task<IClientSessionHandle> StartSessionAsync()
    {
        return await _client.StartSessionAsync(new ClientSessionOptions());
    }
