    public static async Task UseAsync(Func<T, Task> action)
    {
        ...
        try
        {
            await action(Client);
            ...
    }
