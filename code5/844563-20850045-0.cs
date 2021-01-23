    public async Task DoDbOperations()
    {
        await Task.Run(async () =>
        {
             // Your DB operations goes here
    
             // Any work on the UI should go on the Dispatcher
             await Application.Current.Dispatcher.InvokeAsync(() => {
                 // UI updates
             });
        });
    }
