    public class BoundedBuffer<T>
    {
        private readonly SemaphoreSlim _locker = new SemaphoreSlim(1,1);
        private readonly int _maxCount = 1000;
        private readonly Queue<T> _items;
        
        public int Count { get { return _items.Count; } }
        
        public BoundedBuffer()
        {
            _items = new Queue<T>(_maxCount);
        }
        
        public BoundedBuffer(int maxCount)
        {
            _maxCount = maxCount;
            _items = new Queue<T>(_maxCount);
        }
        
        public void Put(T item, CancellationToken token)
        {
            _locker.Wait(token);
            
            try
            {
                while(_maxCount == _items.Count)
                {
                    _locker.Release();
                    Thread.SpinWait(1000);
                    _locker.Wait(token);
                }
                
                _items.Enqueue(item);
            }
            catch(OperationCanceledException)
            {
                try
                {
                    _locker.Release();
                }
                catch(SemaphoreFullException) { }
                
                throw;
            }
            finally
            {
                if(!token.IsCancellationRequested)
                {
                    _locker.Release();
                }
            }
        }
        
        public T Take(CancellationToken token)
        {
            _locker.Wait(token);
            
            try
            {
                while(0 == _items.Count)
                {
                    _locker.Release();
                    Thread.SpinWait(1000);
                    _locker.Wait(token);
                }
                
                return _items.Dequeue();
            }
            catch(OperationCanceledException)
            {
                try
                {
                    _locker.Release();
                }
                catch(SemaphoreFullException) { }
                
                throw;
            }
            finally
            {
                if(!token.IsCancellationRequested)
                {
                    _locker.Release();
                }
            }
        }
    }
