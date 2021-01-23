    someInstance.Shutdown += OnShutdown1;
    someInstance.Shutdown += OnShutdown2;
    ...
    private async Task OnShutdown1(SomeClass source, MyEventArgs args)
    {
        if (!args.IsProcessed)
        {
            // An operation
            await Task.Delay(123);
            args.IsProcessed = true;
        }
    }
    private async Task OnShutdown2(SomeClass source, MyEventArgs args)
    {
        // OnShutdown2 will start execution the moment OnShutdown1 hits await
        // and will proceed to the operation, which is not the desired behavior.
        // Or it can be just a concurrent DB call using the same connection
        // which can result in an exception thrown base on the provider and connection string options
        if (!args.IsProcessed)
        {
            // An operation
            await Task.Delay(123);
            args.IsProcessed = true;
        }
    }
