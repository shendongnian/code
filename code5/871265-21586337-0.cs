    button1.IsEnabled = false;
    Task.Factory.StartNew(() => {
        // some code (its take about 2-5 sec)
    }).ContinueWith(task => {
        button1.IsEnabled = true;
    }, TaskScheduler.FromCurrentSynchronizationContext());
