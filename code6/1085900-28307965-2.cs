    public class NoSynchronizationContextScope : IDisposable
    {
        private readonly SynchronizationContext _synchronizationContext;
        public NoSynchronizationContextScope()
        {
            _synchronizationContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
        }
        public void Dispose()
        {
            SynchronizationContext.SetSynchronizationContext(_synchronizationContext);
        }
    }
