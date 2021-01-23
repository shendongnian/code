        public async Task<Disposable> CreateDisposableAsync()
        {
            return new Disposable(this, await PopAsync());
        }
        public class Disposable : IDisposable
        {
            private readonly ObjectPool<TItem> _pool;
            private readonly TItem _item;
            public TItem Item
            {
                get { return _item; }
            }
            public Disposable(ObjectPool<TItem> pool, TItem item)
            {
                _pool = pool;
                _item = item;
            }
            public void Dispose()
            {
                _pool.Push(Item);
            }
        }
