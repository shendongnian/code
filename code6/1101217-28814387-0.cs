    public async Task<TResult> Try<TResult>(Func<IDataServices, Task<TResult>> method)
    {
        using (IDataServices client = GetClient())
        {
            return (TResult)await method(client)
        }
    }
