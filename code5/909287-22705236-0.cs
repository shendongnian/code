    public class Promise
    {
        readonly Task _task;
        readonly CancellationTokenSource _cts;
        readonly object _lock = new Object();
        Exception _exception = null;
        bool _cancelled = false;
        // public API
        public Promise()
        {
            _cts = new CancellationTokenSource();
            _task = new Task(CompletionAction, _cts.Token); 
        }
        public Task Task { get { return _task; } }
        public void SetCompleted(TaskScheduler sheduler = null)
        {
            lock(_lock)
                Complete(sheduler);
        }
        public void SetException(Exception ex, TaskScheduler sheduler = null)
        {
            lock (_lock)
            {
                _exception = ex;
                Complete(sheduler);
            }
        }
        public void SetCancelled(TaskScheduler sheduler = null)
        {
            lock (_lock)
            {
                // don't call "_cts.Cancel()" here
                // otherwise the cancellation won't be done on "sheduler"
                _cancelled = true;
                Complete(sheduler);
            }
        }
        // implementation
        void CompletionAction()
        {
            if (_cancelled)
            {
                _cts.Cancel();
                _cts.Token.ThrowIfCancellationRequested();
            }
            if (_exception != null)
                throw _exception;
        }
        void Complete(TaskScheduler sheduler)
        {
            if (Task.Status != TaskStatus.Created)
                throw new InvalidOperationException("Invalid task state.");
            _task.RunSynchronously(sheduler?? TaskScheduler.Current);
        }
    }
