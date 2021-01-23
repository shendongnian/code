    private readonly SemaphoreSlim Mutex = new SemaphoreSlim(1, 1);
    private CancellationTokenSource CancellationTokenSource;
    private void OnTextChanged(object sender, TextChangedEventArgs args)
    {
        var newCts = new CancellationTokenSource();
        var oldCts = Interlocked.Exchange(ref this.CancellationTokenSource, newCts);
        if (oldCts != null)
        {
            oldCts.Cancel();
        }
        var cancellationToken = newCts.Token;
        var textBox = (sender as TextBox);
        if (textBox != null)
        {
            // Personally I would be capturing
            // TaskScheduler.FromCurrentSynchronizationContext()
            // here and then scheduling a continuation using that (UI) scheduler.
            Task.Factory.StartNew(() =>
            {
                // Ensure that only one thread can execute
                // the try body at any given time.
                this.Mutex.Wait(cancellationToken);
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    RunSearch(cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                    //Copy temporary collection to UI bound ObservableCollection 
                    //on UI thread
                    Application.Current.Dispatcher.Invoke(new Action(() => MyClass.Instance.SearchMarkers = tempItems));
                }
                finally
                {
                    this.Mutex.Release();
                }
            }, cancellationToken);
        }
    }
