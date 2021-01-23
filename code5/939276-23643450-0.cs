    public Task Get()
    {
        return Task.FromResult(1)
                   .SafeContinueWith(_ => { })
                   .SafeContinueWith(_ => Ok(DateTime.Now.ToLongTimeString()));
    }
