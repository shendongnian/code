    public async Task<TResult> TryAsync<TResult>(Func<IDataServices, Task<TResult>> method)
    {
        using (IDataServices client = GetClient())
        {
            return await method(client).ConfigureAwait(false);
        }
    }
