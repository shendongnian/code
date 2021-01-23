    var tokenSource = new CancellationTokenSource();
    var token = tokenSource.Token;
    Task.Run(() => 
    {
        for(int i = 0; i <= 100000000; i++)
        {
            ...
            // check if the task has been cancelled and throw if required
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested();
            // otherwise update the UI
            someTextBox.Invoke(() => someTextBox.Text = String.Format("Iteration: {0}", i));
        }
    }
    , token);
    // cancel the task after 5 seconds
    Task.Run(async delegate 
    {
        await Task.Delay(5000); 
        tokenSource.Cancel(); 
    });
