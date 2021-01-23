    private async void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
    {
        try
        {
            args.CheckResult();
        }
        catch(Exception e)
        {
            // add a log/breakpoint here
        }
    }
