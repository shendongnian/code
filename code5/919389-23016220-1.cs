    // UI thread
    var uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    using (var worker = new ThreadWithPumpingSyncContext())
    {
        // call the worker thread
        var result = await worker.Run(async () => 
        {
            // worker thread
            await Task.Delay(1000);
            // call the UI thread
            await Task.Factory.StartNew(async () => 
            {
                // UI thread
                await Task.Delay(2000);
                MessageBox.Show("UI Thread!"), 
                // call the worker thread
                await worker.Run(() => 
                {
                    // worker thread
                    Thread.Sleep(3000)
                });
                // UI thread
                await Task.Delay(4000);
            }, uiTaskScheduler).Unwrap();
            // worker thread
            await Task.Delay(5000);
            return Type.Missing; // or implement a non-generic version of Run
        });
    }
    // ...
    // ThreadWithSerialSyncContext renamed to ThreadWithPumpingSyncContext
    class ThreadWithPumpingSyncContext : SynchronizationContext, IDisposable
    {
        public readonly TaskScheduler Scheduler; // can be used to run tasks on the pumping thread
        readonly Task _mainThreadTask; // wrap the pumping thread as Task
        readonly BlockingCollection<Action> _actions = new BlockingCollection<Action>();
        // track async void methods
        readonly object _lock = new Object();
        volatile int _pendingOps = 0; // the number of pending async void method calls
        volatile TaskCompletionSource<Empty> _pendingOpsTcs = null; // to wait for pending async void method calls
        public ThreadWithPumpingSyncContext()
        {
            var tcs = new TaskCompletionSource<TaskScheduler>();
            _mainThreadTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    SynchronizationContext.SetSynchronizationContext(this);
                    tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
                    // pumping loop
                    foreach (var action in _actions.GetConsumingEnumerable())
                        action();
                }
                finally
                {
                    SynchronizationContext.SetSynchronizationContext(null);
                }
            }, TaskCreationOptions.LongRunning);
            Scheduler = tcs.Task.Result;
        }
        // SynchronizationContext methods
        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
        public override void OperationStarted()
        {
            lock (_lock)
            {
                if (_pendingOpsTcs != null && _pendingOpsTcs.Task.IsCompleted)
                    throw new InvalidOperationException("OperationStarted"); // shutdown requested
                _pendingOps++;
            }
        }
        public override void OperationCompleted()
        {
            lock (_lock)
            {
                _pendingOps--;
                if (0 == _pendingOps && null != _pendingOpsTcs)
                    _pendingOpsTcs.SetResult(Empty.Value);
            }
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            _actions.Add(() => d(state));
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotImplementedException("Send");
        }
        // Task start helpers
        public Task Run(Action action, CancellationToken token = default(CancellationToken))
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this.Scheduler);
        }
        public Task Run(Func<Task> action, CancellationToken token = default(CancellationToken))
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this.Scheduler).Unwrap();
        }
        public Task<T> Run<T>(Func<Task<T>> action, CancellationToken token = default(CancellationToken))
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this.Scheduler).Unwrap();
        }
        // IDispose
        public void Dispose()
        {
            var disposingAlready = false;
            lock (_lock)
            {
                disposingAlready = null != _pendingOpsTcs;
                if (!disposingAlready)
                {
                    // do not allow new async void method calls
                    _pendingOpsTcs = new TaskCompletionSource<Empty>();
                    if (0 == _pendingOps)
                        _pendingOpsTcs.TrySetResult(Empty.Value);
                }
            }
            // outside the lock
            if (!disposingAlready)
            {
                // wait for pending async void method calls
                _pendingOpsTcs.Task.Wait();
                // request the end of the pumping loop
                _actions.CompleteAdding();
            }
            _mainThreadTask.Wait();
        }
        struct Empty { public static readonly Empty Value = default(Empty); }
    }
