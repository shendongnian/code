    public async Task DoSomething()
    {
        App.Current.Dispatcher.Invoke(async () =>
        {
            var x = await ...;
        });
    }
