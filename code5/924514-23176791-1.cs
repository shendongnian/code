    /// <summary>
    /// PumpWithSyncContext, based on AsyncPump
    /// http://blogs.msdn.com/b/pfxteam/archive/2012/02/02/await-synchronizationcontext-and-console-apps-part-3.aspx
    /// </summary>
    class PumpWithSyncContext : SynchronizationContext
    {
        BlockingCollection<Action> _actions;
        int _pendingOps = 0;
        public TResult Run<TResult>(Func<Task<TResult>> taskFunc, CancellationToken token = default(CancellationToken))
        {
            SynchronizationContext.SetSynchronizationContext(this);
            try
            {
                _actions = new BlockingCollection<Action>();
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                var task = Task.Factory.StartNew(
                    async () =>
                    {
                        OperationStarted();
                        try
                        {
                            return await taskFunc();
                        }
                        finally
                        {
                            OperationCompleted();
                        }
                    },
                    token, TaskCreationOptions.None, scheduler).Unwrap();
                // the pumping loop
                foreach (var action in _actions.GetConsumingEnumerable())
                    action();
                return task.GetAwaiter().GetResult();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(null);
            }
        }
        void Complete()
        {
            _actions.CompleteAdding();
        }
        // SynchronizationContext methods
        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
        public override void OperationStarted()
        {
            // called when async void method is invoked 
            Interlocked.Increment(ref _pendingOps);
        }
        public override void OperationCompleted()
        {
            // called when async void method completes 
            if (Interlocked.Decrement(ref _pendingOps) == 0)
                Complete();
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            _actions.Add(() => d(state));
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotImplementedException("Send");
        }
    }
