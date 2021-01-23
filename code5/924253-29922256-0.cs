    public sealed class AsyncLock : IDisposable
    {
        readonly AutoResetEvent Value;
        public AsyncLock(AutoResetEvent value, int milliseconds = Timeout.Infinite)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            value.WaitOne(milliseconds);
            Value = value;
        }
        void IDisposable.Dispose()
        {
            Value.Set();
        }
    }
            
    private async Task TestProc()
    {
        var guard = new AutoResetEvent(true); // Guard for resource
        using (new AsyncLock(guard)) // Lock resource
        {
            await ProcessNewClientOrders(); // Use resource
        } // Unlock resource
    }
