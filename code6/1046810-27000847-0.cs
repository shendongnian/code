    BlockingCollection<string> _filesToProcess = new BlockingCollection<string>();
    // start 8 tasks to do the processing
    List<Task> _consumers = new List<Task>();
    for (int i = 0; i < 8; ++i)
    {
        var t = Task.Factory.StartNew(ProcessFiles, TaskCreationOptions.LongRunning);
        _consumers.Add(t);
    }
    // Populate the queue
    foreach (var filename in filelist)
    {
        _filesToProcess.Add(filename);
    }
    // Mark the collection as complete for adding
    _filesToProcess.CompleteAdding();
    // wait for consumers to finish
    Task.WaitAll(_consumers.ToArray(), Timeout.Infinite);
