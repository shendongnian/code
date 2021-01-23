    SynchronizationContext.SetSynchronizationContext(new BlockingSynchronizationContext(_workQueue));
    var mainTask = main(); // schedule "main" task
    mainTask.ContinueWith(task => _workQueue.CompleteAdding());
    RunMessageLoop();
    return mainTask.Result;
