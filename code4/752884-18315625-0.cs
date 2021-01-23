    public static async Task WithAggregateException(this Task source)
    {
        try
        {
            await source.ConfigureAwait(false);
        }
        catch
        {
            throw source.Exception;
        }
    }
