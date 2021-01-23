    Task t = Task.Factory.StartNew(() =>
    {
        var process = new Task(() =>
        {
            //Copy here the process logic. 
        }, TaskCreationOptions.AttachedToParent);
        //*Private failure handler*.
        process.start();
    });
    try
    {
        t.Wait();
    }
    catch (AggregateException ae)
    {
        //handle exceptions from process.
    }
