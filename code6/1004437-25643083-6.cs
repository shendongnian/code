    public async Task<Disposable> GetDisposableAsync()
    {
        return new Disposable(this, await PopAsync());
    }
    public class Disposable : IDisposable
    {
        private readonly ObjectPool<TItem> _pool;
        public TItem Item { get; set; }
        public Disposable(ObjectPool<TItem> pool, TItem item)
        {
            Item = item;
            _pool = pool;
        }
        public void Dispose()
        {
            _pool.Push(Item);
        }
    }
