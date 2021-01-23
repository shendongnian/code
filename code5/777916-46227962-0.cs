    class SelfCancelRestartTask
    {
        private Task _task = null;
        public CancellationTokenSource TokenSource { get; set; } = null;
    
        public SelfCancelRestartTask()
        {
        }
    
        public async Task Run(Action operation)
        {
            if (this._task != null &&
                !this._task.IsCanceled &&
                !this._task.IsCompleted &&
                !this._task.IsFaulted)
            {
                TokenSource?.Cancel();
                await this._task;
                TokenSource = new CancellationTokenSource();
            }
            else
            {
                TokenSource = new CancellationTokenSource();
            }
            this._task = Task.Run(operation, TokenSource.Token);
        }
