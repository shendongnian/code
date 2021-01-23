    class PoolItem<T> : IDisposable
    {
        public event EventHandler<EventArgs> Disposed;
        public PoolItem(T wrapped)
        {
            WrappedObject = wrapped;
        }
        public T WrappedObject { get; private set; }
        public void Dispose()
        {
            Disposed(this, EventArgs.Empty);
        }
    }
