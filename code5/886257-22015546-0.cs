    public async Task DoStuff()
    {
        object somedata = await FetchData();
        while (somedata != null)
        {
            Task.WaitAny(WriteData(somedata));
            somedata = await FetchData();
        }
    }
    // Whatever method fetches data.
    public Task<object> FetchData()
    {
        var data = new object();
        return Task.FromResult(data);
    }
    // Whatever method writes data.
    public Task WriteData(object somedata)
    {
        return Task.Run(() => { /* write data */});
    }
