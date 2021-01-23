    public class ThresholdBuffer<T>
    {
        private ConcurrentBag<T> _buffer;
        private int _copacity;
        private int _threshold;
        public ThresholdBuffer(int threshold)
        {
            _threshold = threshold;
            _copacity = 0;
            _buffer = new ConcurrentBag<T>();
        }
        public void Add(T item)
        {
            _buffer.Add(item);
            if (Interlocked.Increment(ref _copacity) == _threshold)
            {
                Recycle();
            }
        }
        public void Recycle()
        {
            var value4flasshing = Interlocked.Exchange<ConcurrentBag<T>>(ref _buffer, new ConcurrentBag<T>());
            Thread.VolatileWrite(ref _copacity, 0);
        }
    }
