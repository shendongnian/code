    async Task MyProcess() //the Task is returned implicitly
    {
        busyIndicator.Visibility = Visibility.Visible;
        await LongRunningMethod(); //the work here is done in a worker thread
        busyIndicator.Visibility = Visibility.Collapsed; //this line executes back on the ui context
    }
    Task LongRunningMethod() //the Async suffix is a convention to differentiate overloads that return Tasks
    {
        var result1 = await Task.Run(() => /* do some processing */ ); //we are actually starting an asynchronous task here.
        //update some ui elements here
        var result2 = await Task.Run(() => /* do some more processing */ );
        //update some ui elements here
    }
