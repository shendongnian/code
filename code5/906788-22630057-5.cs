    public static Task HandleFault(this Task task, CancellationToken cancelToken)
    {
        return task.ContinueWith(
            t => { WriteLog(t.Exception); },
            cancelToken,
            TaskContinuationOptions.OnlyOnFaulted,
            TaskScheduler.Default);
    }
    public async Task StartWorkAsync()
    {
        System.Web.Hosting.HostingEnvironment.QueueBackgroundWorkItem(
            cancelToken => this.WorkAsync().HandleFault(cancelToken));
    }
