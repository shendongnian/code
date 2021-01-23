    ...
    Timer.Start(Handle_Tick)
    ...
    
    public void Handle_Tick(...)
    {
        //Check to see if we're already busy. We don't need to "pump" the work if
        //we're already processing.
        if (IsBusy)
            return;
    
        try
        {
            IsBusy = true;
            //Perform your work
        }
        finally
        {
            IsBusy = false;
        }
    }
