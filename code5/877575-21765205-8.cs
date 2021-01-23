    // fire ExecuteCompleted and pass TaskCompletedEventArgs 
    class TaskCompletedEventArgs : EventArgs
    {
        public TaskCompletedEventArgs(Task task)
        {
            this.Task = task;
        }
        public Task Task { get; private set; }
    }
    EventHandler<TaskCompletedEventArgs> ExecuteCompleted = (s, e) => { };
    CancellationTokenSource _cts = null;
    Task _executeTask = null;
    // ... 
    _cts = new CancellationTokenSource();
    _executeTask = DoUIThreadWorkLegacyAsync(_cts.Token);
    // don't await here
    var continutation = _executeTask.ContinueWith(
        task => this.ExecuteCompleted(this, new TaskCompletedEventArgs(task)),
        _cts.Token,
        TaskContinuationOptions.ExecuteSynchronously,
        TaskScheduler.FromCurrentSynchronizationContext());
