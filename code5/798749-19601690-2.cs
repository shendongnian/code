    public Task<TReply> SendAsync<TReply>(Query query) where TReply : Reply, new()
    {
        return Task.Run(() =>
        {
            return Send<TReply>(query);
        });
    }
