    public IDisposable DisableOptimisticConcurrency()
    {
        DatabaseContext.Advanced.UseOptimisticConcurrency = false;
        return new DisposeAdapter(() =>
        {
            DatabaseContext.Advanced.UseOptimisticConcurrency = true;
        });
    }
    public class DisposeAdapter : IDisposable
    {
        private readonly Action performOnDispose;
        private int disposed = 0;
        public DisposeAdapter(Action performOnDispose)
        {
            if (performOnDispose == null)
                throw new ArgumentNullException("performOnDispose");
            this.performOnDispose = performOnDispose;
        }
        public void Dispose()
        {
             if (Interlocked.Exchange(ref this.disposed, 1) == 0)
                 this.performOnDispose();
        }
    }
    using (DisableOptimisticConcurrency())
    {
        // perform action
    }
