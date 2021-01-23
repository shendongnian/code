    // handle the completion asynchronously with a blocking wait
    void RunProcessSync()
    {
        try
        {
            Process(_cancellationTokenSource.Token).Wait();
            MessageBox.Show("Process complete");
        }
        catch (Exception e)
        {
            MessageBox.Show("Process cancelled (or faulted): " + e.Message);
        }
    }
    
    // handle the completion asynchronously using ContinueWith
    Task RunProcessAync()
    {
        return Process(_cancellationTokenSource.Token).ContinueWith((task) =>
        {
            // check task.Status here
            MessageBox.Show("Process complete (or cancelled, or faulted)");
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    // handle the completion asynchronously with async/await
    async Task RunProcessAync()
    {
        try
        {
            await Process(_cancellationTokenSource.Token);
            MessageBox.Show("Process complete");
        }
        catch (Exception e)
        {
            MessageBox.Show("Process cancelled (or faulted): " + e.Message);
        }
    }
