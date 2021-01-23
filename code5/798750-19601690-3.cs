    public dynamic Send<TReply>(Query query, bool sendAsync) where TReply : Reply, new()
    {
        if (sendAsync)
        {
            return Task.Run(() =>
            {
                return Send<TReply>(query);
            }
        }
        else
        {
            return Send<TReply>(query);
        }
    }
