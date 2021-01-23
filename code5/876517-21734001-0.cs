    // version 1
    public class Thing
    {
        public void Close() { ... }
    }
    
    // version 2
    public class Thing : IDisposable
    {
        public void Close() { ... }
        void IDisposable.Dispose() { Close(); }
    }
