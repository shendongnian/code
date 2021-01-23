    BlockingCollection<Uri> UrlQueue = new BlockingCollection<Uri>();
    // Main thread starts the consumer threads
    Task t1 = Task.Factory.StartNew(() => ProcessUrls, TaskCreationOptions.LongRunning);
    Task t2 = Task.Factory.StartNew(() => ProcessUrls, TaskCreationOptions.LongRunning);
    // create more tasks if you think necessary.
    // Now read your file
    foreach (var line in File.ReadLines(inputFileName))
    {
        var theUri = ExtractUriFromLine(line);
        UrlQueue.Add(theUri);
    }
    // when done adding lines to the queue, mark the queue as complete
    UrlQueue.CompleteAdding();
    // now wait for the tasks to complete.
    t1.Wait();
    t2.Wait();
    // You could also use Task.WaitAll if you have an array of tasks
