    public class Promise
    {
        readonly Task _task;
        readonly CancellationTokenSource _cts;
        readonly object _lock = new Object();
        Action _completionAction = null;
        // public API
        public Promise()
        {
            _cts = new CancellationTokenSource();
            _task = new Task(InvokeCompletionAction, _cts.Token); 
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
                _completionAction = () => { throw ex; };
                Complete(sheduler);
            }
        }
        public void SetException(System.Runtime.ExceptionServices.ExceptionDispatchInfo edi, TaskScheduler sheduler = null)
        {
            lock (_lock)
            {
                _completionAction = () => { edi.Throw(); };
                Complete(sheduler);
            }
        }
        public void SetCancelled(TaskScheduler sheduler = null)
        {
            lock (_lock)
            {
                // don't call _cts.Cancel() outside _completionAction
                // otherwise the cancellation won't be done on the sheduler
                _completionAction = () =>
                {
                    _cts.Cancel();
                    _cts.Token.ThrowIfCancellationRequested();
                };
                Complete(sheduler);
            }
        }
        // implementation
        void InvokeCompletionAction()
        {
            if (_completionAction != null)
                _completionAction();
        }
        void Complete(TaskScheduler sheduler)
        {
            if (Task.Status != TaskStatus.Created)
                throw new InvalidOperationException("Invalid task state.");
            _task.RunSynchronously(sheduler?? TaskScheduler.Current);
        }
    }
