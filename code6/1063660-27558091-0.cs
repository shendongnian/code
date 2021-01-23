    public async Task SomeMethod()
    {
        var temp = await someService.SomeAsyncMethod();
        lock (_lock)
        {
            SomeProperty = temp;
        }
    }
