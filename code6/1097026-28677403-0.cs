    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        _searchCancellationTokenSrc = new CancellationTokenSource();
        CancellationToken ct = _searchCancellationTokenSrc.Token;
        _searchTask = Task.Run(() =>
        {
             for (int i = 0; i < 10; i++ )
             {
                 if(ct.IsCancellationRequested)
                 {
                     // Clean up here
                     ct.ThrowIfCancellationRequested();
                 }
                 // Time consuming processing here
                 Thread.Sleep(1000);
             }
             return new Move();
        },ct);
        _searchTask.ContinueWith((t) =>
        {
             Console.WriteLine("Canceled");
        }, TaskContinuationOptions.OnlyOnCanceled);
        _searchTask.ContinueWith((t) =>
        {
           Console.WriteLine("Faulted. t.Exception contains details of any exceptions thrown");               
        }, TaskContinuationOptions.OnlyOnFaulted);
        _searchTask.ContinueWith((t) =>
        {            
            Console.WriteLine("Completed t.Result contains your Move object");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
    }
