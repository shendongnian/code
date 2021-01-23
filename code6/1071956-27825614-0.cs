    private void GetBlocking_Click(object sender, RoutedEventArgs e)
    {
        Task.FromResult(true)
            .ContinueWith(t =>{ }, 
                TaskScheduler.FromCurrentSynchronizationContext())
            .Wait();
    }
