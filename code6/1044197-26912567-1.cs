    public static async Task<TResult> UseAsync(Func<TClient, Task<TResult>> action)
    {
        ...
        TResult result;
        try
        {
            result = await action(Client);
            ...
        return result;
    }
