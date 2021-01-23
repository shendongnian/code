    public static class TaskExt
    {
        static public void SetResultAsync<T>(this TaskCompletionSource<T> tcs, T result)
        {
            FakeSynchronizationContext.Execute(() => tcs.SetResult(result));
        }
        // FakeSynchronizationContext
        class FakeSynchronizationContext : SynchronizationContext
        {
            private static readonly ThreadLocal<FakeSynchronizationContext> s_context =
                new ThreadLocal<FakeSynchronizationContext>(() => new FakeSynchronizationContext());
            private FakeSynchronizationContext() { }
            public static FakeSynchronizationContext Instance { get { return s_context.Value; } }
            public static void Execute(Action action)
            {
                var savedContext = SynchronizationContext.Current;
                SynchronizationContext.SetSynchronizationContext(FakeSynchronizationContext.Instance);
                try
                {
                    action();
                }
                finally
                {
                    SynchronizationContext.SetSynchronizationContext(savedContext);
                }
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
                throw new NotImplementedException("Post");
            }
            public override void Send(SendOrPostCallback d, object state)
            {
                throw new NotImplementedException("Send");
            }
        }
    }
