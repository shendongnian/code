    public static class NoSynchronizationContextScope
    {
        public static Disposable Enter()
        {
            SynchronizationContext.SetSynchronizationContext(null);
            return new Disposable(SynchronizationContext.Current);
        }
        public struct Disposable : IDisposable
        {
            private readonly SynchronizationContext _synchronizationContext;
            public Disposable(SynchronizationContext synchronizationContext)
            {
                _synchronizationContext = synchronizationContext;
            }
            public void Dispose() =>
                SynchronizationContext.SetSynchronizationContext(_synchronizationContext);
        }
    }
