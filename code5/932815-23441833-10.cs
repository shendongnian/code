    async Task DoUIThreadWorkAsync(CancellationToken token)
    {
        var i = 0;
    
        while (true)
        {
            token.ThrowIfCancellationRequested();
    
            await Dispatcher.Yield(DispatcherPriority.ApplicationIdle);
    
            // do the UI-related work item
            this.TextBlock.Text = "iteration " + i++;
        }
    }
