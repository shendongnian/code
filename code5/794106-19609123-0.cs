    public class ThresholdBuffer<T>
    {
        private ConcurrentBag<T> _buffer;
    
        private int _threshold;
    
        public ThresholdBuffer(int threshold)
        {
            _threshold = threshold;
            _buffer = new ConcurrentBag<T>();
        }
    
        public void Add(T item)
        {
            _buffer.Add(item);
            
            if(_buffer.Count >= _threshold)
            {
                Recycle();
            }
        }
    
        public void Recycle()
        {
            var value = Interlocked.Exchange<ConcurrentBag<T>>(ref _buffer, new ConcurrentBag<T>());
    //flush value 
        }
    }
