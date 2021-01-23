    void RunProcessSync()
    {
        try
        {
            Process(_cancellationTokenSource.Token).Wait();
            MessageBox.Show("Process complete");
        }
        catch (Exception e)
        {
            MessageBox.Show("Process cancelled (or faulted)", e.Message);
        }
    }
    
    Task RunProcessAync()
    {
        Process(_cancellationTokenSource.Token).ContinueWith(() =>
        {
            MessageBox.Show("Process complete (or cancelled, or faulted)");
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    async Task RunProcessAync()
    {
        try
        {
            await Process(_cancellationTokenSource.Token);
        }
        catch (Exception e)
        {
            MessageBox.Show("Process cancelled (or faulted)", e.Message);
        }
    }
