    // This
    public async Task<TOut> CallAsyncFunc<TIn, TOut>(TIn input, Func<TIn, Task<TOut>> func)
    {
        return await func.Invoke(input);
    }
    // Or those
    public Task<TOut> CallAsyncFunc<TIn, TOut>(TIn input, Func<TIn, Task<TOut>> func)
    {
        return func.Invoke(input);
    }
    public async Task<string> GetString(int value)
    {
        await Task.Run(() => Thread.Sleep(2000));
        return value.ToString(CultureInfo.InvariantCulture);
    }
    public async Task MainAsyncEntry()
    {
        string y = await CallAsyncFunc(30, GetString);
    }
