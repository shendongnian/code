    // get the dispatcher for the UI thread
    var uiDispatcher = Dispatcher.CurrentDispatcher;
    var task = BackgroundThreadProc(uiDispatcher));
    // ...
    public async Task BackgroundThreadProc(Dispatcher uiDispatcher)
    {
        for (var i = 0; i < 100; i++)
        {
            await Task.Delay(1000).ConfigureAwait(false);
            
            // create object
            var animal = new Animal { Name = "test" + i };
            uiDispatcher.Invoke(new Action(() => log(animal)));
        }
    }
