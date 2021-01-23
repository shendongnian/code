    async Task MyProcess() //the Task is returned implicitly
    {
        busyIndicator.Visibility = Visibility.Visible;
        await LongRunningMethodAsync(); //the work here is done in a worker thread
        busyIndicator.Visibility = Visibility.Collapsed; //this line executes back on the ui context
    }
    Task LongRunningMethodAsync() //the Async suffix is a convention to differentiate overloads that return Tasks
    {
        return Task.Run(LongRunningMethod); //we are actually starting an asynchronous task here.
    }
