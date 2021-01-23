    public class ObjectPool<TItem>
    {
        private readonly BufferBlock<TItem> _bufferBlock;
        private readonly int _maxSize;
        private readonly Func<TItem> _creator;
        private readonly CancellationToken _cancellationToken;
        private readonly object _lock;
        private int _currentSize;
        public ObjectPool(int maxSize, Func<TItem> creator, CancellationToken cancellationToken)
        {
            _lock = new object();
            _maxSize = maxSize;
            _currentSize = 1;
            _creator = creator;
            _cancellationToken = cancellationToken;
            _bufferBlock = new BufferBlock<TItem>(
                new DataflowBlockOptions
                {
                    CancellationToken = _cancellationToken,
                });
        }
        public void Push(TItem item)
        {
            if (!_bufferBlock.Post(item) || _bufferBlock.Count > _maxSize)
            {
                throw new Exception();
            }
        }
        public Task<TItem> PopAsync()
        {
            TItem item;
            if (_bufferBlock.TryReceive(out item))
            {
                return Task.FromResult(item);
            }
            if (_currentSize < _maxSize)
            {
                lock (_lock)
                {
                    if (_currentSize < _maxSize)
                    {
                        _currentSize++;
                        _bufferBlock.Post(_creator());
                    }
                }
            }
            return _bufferBlock.ReceiveAsync();
        }
    }
