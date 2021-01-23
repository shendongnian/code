    public sealed class Example : IDisposable 
    {
        public EventHandler MyEvent;
    
        public void Dispose()
        {
            MyEvent = null;
        }
    }
