    ThreadWithAffinityContext _staThread;
    
    dynamic _comObject;
    
    private async void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
