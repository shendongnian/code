    dynamic _comObject = null;
    
    ThreadWithAffinityContext _staThread = null;
    
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
    Task _newCommandHandlerTask = null;
    
    // handle a WPF UI command
    private async void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        try
        {
            if (_newCommandHandlerTask != null)
                throw new InvalidOperationException("One NewCommandHandlerAsync at a time!");
    
            _newCommandHandlerTask = NewCommandHandlerAsync();
    
            await _newCommandHandlerTask;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        _newCommandHandler = null;
    }
