    public class WMIReceiveEvent : IDisposable
    {   
        private readonly SynchronizationContext _syncContext;
        public WMIReceiveEvent(SynchronizationContext syncContext)
        {
            _cyncContext = syncContext;
        }
    }
