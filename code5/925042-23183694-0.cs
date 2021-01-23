    customIndeterminateProgressBar.Visibility = System.Windows.Visibility.Visible;
    Task.Run(() =>
    {
       // Do CPU intensive work
    }).ContinueWith(task =>
    {
       customIndeterminateProgressBar.Visibility = System.Windows.Visibility.Collapsed;
    }, TaskScheduler.FromCurrentSynchronizationContext());
