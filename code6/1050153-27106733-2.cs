    public static async Task Async()
    {
        throw new Exception();
        await Task.Delay(1000);
    }
    public static Task TaskReturning()
    {
        throw new Exception();
        return Task.Delay(1000);
    }
