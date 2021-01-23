    public class ColdTaskCompletionSource
    {
        public sealed class FakeTaskScheduler : TaskScheduler
        {
            Task _task;
            public FakeTaskScheduler()
            {
            }
            protected override void QueueTask(Task task)
            {
                _task = task;
            }
            protected sealed override bool TryDequeue(Task task)
            {
                if (task != _task)
                    return false;
                _task = null;
                return true;
            }
            protected override IEnumerable<Task> GetScheduledTasks()
            {
                if (_task == null)
                    yield break;
                yield return _task;
            }
            protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
            {
                return false;
            }
            public override int MaximumConcurrencyLevel
            {
                get { return 1; }
            }
            public bool Execute()
            {
                if (_task == null)
                    return false;
                var task = _task;
                _task = null;
                return base.TryExecuteTask(task);
            }
        }
        readonly Task _task;
        readonly CancellationTokenSource _cts;
        readonly object _lock = new Object();
        readonly FakeTaskScheduler _ts = new FakeTaskScheduler();
        Action _completionAction = null;
        // helpers
        void InvokeCompletionAction()
        {
            if (_completionAction != null)
                _completionAction();
        }
        void Complete()
        {
            if (_task.Status != TaskStatus.WaitingToRun)
                throw new InvalidOperationException("Invalid Task state");
            _ts.Execute();
        }
        // public API
        public ColdTaskCompletionSource()
        {
            _cts = new CancellationTokenSource();
            _task = new Task(InvokeCompletionAction, _cts.Token);
        }
        public Task Task { get { return _task; } }
        public void Start()
        {
            _task.Start(_ts);
        }
        public void SetCompleted()
        {
            lock (_lock)
                Complete();
        }
        public void SetException(Exception ex)
        {
            lock (_lock)
            {
                _completionAction = () => { throw ex; };
                Complete();
            }
        }
        public void SetCancelled()
        {
            lock (_lock)
            {
                _completionAction = () =>
                {
                    _cts.Cancel();
                    _cts.Token.ThrowIfCancellationRequested();
                };
                Complete();
            }
        }
    }
