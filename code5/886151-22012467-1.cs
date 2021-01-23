    TimeSpan period = TimeSpan.FromSeconds(60);
    ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
    {
        // TODO: Work
        
        Deployment.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, 
            () =>
            {
                // UI update               
            });
    }, period);
