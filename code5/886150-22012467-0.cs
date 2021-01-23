    TimeSpan period = TimeSpan.FromSeconds(60);
    ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
    {
        // TODO: Work
        
        Dispatcher.RunAsync(CoreDispatcherPriority.High,
            () =>
            {
                // UI update               
            });
    }, period);
