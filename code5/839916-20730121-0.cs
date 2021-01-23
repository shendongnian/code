    /// <remarks>
    /// If iterating data throws an exception, the target block is faulted
    /// and the returned Task completes successfully.
    /// 
    /// Depending on the usage, this might or might not be what you want.
    /// </remarks>
    public static async Task SendAllAsync<T>(
        this ITargetBlock<T> target, IEnumerable<T> data)
    {
        try
        {
            foreach (var item in data)
            {
                await target.SendAsync(item);
            }
        }
        catch (Exception e)
        {
            target.Fault(e);
        }
    }
