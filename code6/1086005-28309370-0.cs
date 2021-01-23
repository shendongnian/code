    async Task CreateFileFromLongRunningComputation(int input)
    {
        await new NoContextYieldAwaitable();
        // executed on a ThreadPool thread
    }
    public struct NoContextYieldAwaitable
    {
        public NoContextYieldAwaiter GetAwaiter() { return new NoContextYieldAwaiter(); }
        public struct NoContextYieldAwaiter : INotifyCompletion
        {
            public bool IsCompleted { get { return false; } }
            public void OnCompleted(Action continuation)
            {
                var scheduler = TaskScheduler.Current;
                if (scheduler == TaskScheduler.Default)
                {
                    ThreadPool.QueueUserWorkItem(RunAction, continuation);
                }
                else
                {
                    Task.Factory.StartNew(continuation, CancellationToken.None, TaskCreationOptions.PreferFairness, scheduler);
                }
            }
            public void GetResult() { }
            private static void RunAction(object state) { ((Action)state)(); }
        }
    }
