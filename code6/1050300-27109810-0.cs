    public class SyncrhonizationContextChange : IDisposable
    {
        private SynchronizationContext previous;
        public SyncrhonizationContextChange(SynchronizationContext newContext = null)
        {
            previous = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(newContext);
        }
        public void Dispose()
        {
            SynchronizationContext.SetSynchronizationContext(previous);
        }
    }
