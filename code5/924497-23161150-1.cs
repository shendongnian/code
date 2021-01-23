    Task.Factory.StartNew(() =>
        {
            //do something here with your Request.Files[0].InputStream;
        },
        CancellationToken.None,
        TaskCreationOptions.LongRunning, // guarantees separate thread
        TaskScheduler.Default);
