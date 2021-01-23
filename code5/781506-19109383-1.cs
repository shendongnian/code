    async Task SomeMethod(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await Task.Run(() => DoAsyncStuff(), ct);
            DoUIStuff();
            await Task.Delay(TimeSpan.FromMinutes(1), ct);
        }
    }
