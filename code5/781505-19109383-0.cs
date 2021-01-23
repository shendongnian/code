    async Task SomeMethod(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await Task.Run(() => DoAsyncStuff());
            DoUIStuff();
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
