    public class FixedSizedCircularQueue<T>
    {
        private int _maxSize;
        private int _currentIndex;
        private T[] _q;
        
        public FixedSizedCircularQueue(int maxSize)
        {
            _maxSize = maxSize;
            _currentIndex = 0;
            _q = new T[_maxSize];
        }
        
        public void Enqueue(T obj)
        {
            ResetIndexIfMaxSizeExceeded();
            _q[_currentIndex] = obj;
            _currentIndex++;
            
            //for debug
            Console.WriteLine("index: " + _currentIndex + " object: " + obj);
        }
        
        private void ResetIndexIfMaxSizeExceeded()
        {
            if((_currentIndex % _maxSize) == 0) _currentIndex = 0;
        }
    }
