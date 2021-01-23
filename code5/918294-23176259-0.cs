    ActionBlock<object>(
    temp =>
    {
        double progress = (double)temp.RecordNumber/(double)TotalRecords;
        Dispatcher.BeginInvoke((Action)(() =>
        {
            CurrentProgress = progress;
        }));
    },
    new ExecutionDataflowBlockOptions
    {
        TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
    });
