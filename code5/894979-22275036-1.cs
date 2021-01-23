    public static async Task IgnoreException(this Task task)
    {
        try
        {
            await task;
        }
        catch {}
    }
