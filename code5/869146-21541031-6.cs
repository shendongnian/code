    dynamic _comObject = null;
    
    ThreadWithAffinityContext _staThread = null;
    
    // Start the long-running task
    Task NewCommandHandlerAsync()
    {
        // create the ThreadWithAffinityContext if haven't done this yet
        if (_staThread == null)
            _staThread = new ThreadWithAffinityContext(
                staThread: true,
                pumpMessages: true);
    
        // create the COM Object if haven't done this yet
        if (_comObject == null)
        {
            await _staThread.Run(() =>
            {
                // _comObject will live on a dedicated STA thread,
                // run by ThreadWithAffinityContext
                _comObject = new ComObject();
            }, CancellationToken.None);
        }
    
        // use the COM object
        await _staThread.Run(() =>
        {
            // run a lengthy process
            _comObject.DoWork();
        }, CancellationToken.None);
    }
    
    // keep track of pending NewCommandHandlerAsync
    Task _newCommandHandler = null;
    
    // handle a WPF command
    private async void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        try
        {
            // avoid re-entrancy (i.e., running two NewCommandHandlerAsync in parallel)
            if (_newCommandHandler != null)
                throw new InvalidOperationException("One NewCommandHandlerAsync at a time!");
            try
            {
                await _newCommandHandler = NewCommandHandlerAsync();
            }
            finally
            {
                _newCommandHandler = null;
            }
        }
        catch (Exception ex)
        {
            // handle all exceptions possibly thrown inside "async void" method
            MessageBox.Show(ex.Message);
        }
    }
