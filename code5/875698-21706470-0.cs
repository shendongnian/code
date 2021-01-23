    public void OnIndication()
    {
    Task doWork = new Task(() =>
        {
            // Handle request
        });
        Action<Task> onComplete = (task) =>
        {                
            SendRepeatRequest(X, args)
        };
        doWork.Start(); 
        doWork.ContinueWith(onComplete, TaskScheduler.FromCurrentSynchronizationContext());                       
    }
