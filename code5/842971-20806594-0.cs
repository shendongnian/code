    async void StartButtonClicked()
    {
        startButton.IsEnabled = false;
        
        await DoSomeWork();
        
        startButton.IsEnabled = true;
    }
    
    Task DoSomeWork()
    {
        // Do some long running background task here.
    }
