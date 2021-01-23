    public class OverwriteTaskHandler<T>
    {
        private Task<T> _task;
        private TaskCompletionSource<T> _tcs;
        private CancellationTokenSource _cts;
        public OverwriteTaskHandler(Func<T> operation)
        {
            _tcs = new TaskCompletionSource<T>();
            _cts = new CancellationTokenSource();
            TryPushTask(operation);
        }
        public bool TryPushTask(Func<T> operation)
        {
            if (_tcs.Task.IsCompleted)
                return false;   //It would be unsafe to use this instance as it is already "finished"
            _cts.Cancel();
            _cts = new CancellationTokenSource();
            _task = Task.Run(operation, _cts.Token);
            _task.ContinueWith(task => _tcs.SetResult(task.Result));
            return true;
        }
        public void Cancel()
        {
            _cts.Cancel();
        }
        public Task<T> WrappedTask { get { return _tcs.Task; } }
    }
