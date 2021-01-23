    public class GenericConcurrentPool<T> : IDisposable where T : class
    {
        private readonly SemaphoreSlim _sem;
        private readonly ConcurrentStack<T> _itemsStack;
        private readonly Action<T> _onDisposeItem;
        private readonly Func<T> _factory;
        public GenericConcurrentPool(int capacity, Func<T> factory, Action<T> onDisposeItem = null)
        {
            _itemsStack = new ConcurrentStack<T>(new T[capacity]);
            _factory = factory;
            _onDisposeItem = onDisposeItem;
            _sem = new SemaphoreSlim(capacity);
        }
        public async Task<T> CheckOutAsync()
        {
            await _sem.WaitAsync();
            return Pop();
        }
        public T CheckOut()
        {
            _sem.Wait();
            return Pop();
        }
        public void CheckIn(T item)
        {
            Push(item);
            _sem.Release();
        }
        public void Dispose()
        {
            _sem.Dispose();
            if (_onDisposeItem != null)
            {
                T item;
                while (_itemsStack.TryPop(out item))
                {
                    if (item != null)
                        _onDisposeItem(item);
                }
            }
        }
        private T Pop()
        {
            T item;
            var result = _itemsStack.TryPop(out item);
            Debug.Assert(result);
            return item ?? _factory();
        }
        private void Push(T item)
        {
            Debug.Assert(item != null);
            _itemsStack.Push(item);
        }
    }
