    // UI thread
    var uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    using (var worker = new ThreadWithSerialSyncContext())
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
                }, CancellationToken.None);
                // UI thread
                await Task.Delay(4000);
            }, uiTaskScheduler).Unwrap();
            // worker thread
            await Task.Delay(5000);
            return true;
        }, CancellationToken.None);
    }
    // ...
    class ThreadWithSerialSyncContext : SynchronizationContext, IDisposable
    {
        readonly Task _mainTask;
        readonly TaskScheduler _scheduler;
        readonly BlockingCollection<Action> _tasks = new BlockingCollection<Action>();
        public ThreadWithSerialSyncContext()
        {
            var tcs = new TaskCompletionSource<TaskScheduler>();
            _mainTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    SynchronizationContext.SetSynchronizationContext(this);
                    tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
                    foreach (var task in _tasks.GetConsumingEnumerable())
                        task();
                }
                finally
                {
                    SynchronizationContext.SetSynchronizationContext(null);
                }
            }, TaskCreationOptions.LongRunning);
            _scheduler = tcs.Task.Result;
        }
        // SynchronizationContext methods
        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
        public override void OperationStarted()
        {
            throw new NotImplementedException("OperationStarted");
        }
        public override void OperationCompleted()
        {
            throw new NotImplementedException("OperationCompleted");
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            _tasks.Add(() => d(state));
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotImplementedException("Send");
        }
        // helpers
        public Task Run(Action action, CancellationToken token)
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _scheduler);
        }
        public Task Run(Func<Task> action, CancellationToken token)
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _scheduler).Unwrap();
        }
        public Task<T> Run<T>(Func<Task<T>> action, CancellationToken token)
        {
            return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _scheduler).Unwrap();
        }
        // IDispose
        public void Dispose()
        {
            if (_mainTask == null || _mainTask.IsCompleted)
                return;
            _tasks.CompleteAdding();
            _mainTask.Wait();
        }
    }
