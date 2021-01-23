    //Check to see if we're already busy. We don't need to "pump" the work if
    //we're already processing.
    if (IsBusy)
        return;
    try
    {
        //Perform your work
    }
    finally
    {
        IsBusy = false;
    }
