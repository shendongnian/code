    public async Task StartMonitoring(int interval, CancellationToken token)
    {
        this.establishContext();
        while (true)
        {
            token.ThrowIfCancellationRequested();
            if (IsReaderArrived())
            {
                // make sure to reset the flag inside IsReaderArrived
                // so the event won't be fired upon the next iteration 
 
                if (this.CardArrived != null)
                    this.CardArrived(this, EventArgs.Empty);
            }
            await Task.Delay(interval);
        }
    }
