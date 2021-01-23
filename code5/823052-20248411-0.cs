    public async void Run(IBackgroundTaskInstance task)
    {
        BackgroundTaskDeferral deferral = task.GetDeferral();
        await Something(); //...
        deferral.Complete();
    }
