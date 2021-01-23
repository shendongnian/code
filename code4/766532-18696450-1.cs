    Task.Factory.StartNew(new Action(() =>
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
    }), new CancellationToken(), TaskCreationOptions.None, 
    TaskScheduler.FromCurrentSynchronizationContext()).
    ContinueWith(new Action(() => DoFunction1)).
    ContinueWith(new Action(() =>
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3Enabled = false;
    }), TaskScheduler.FromCurrentSynchronizationContext()).
    ContinueWith(new Action(() => DoFunction2));
