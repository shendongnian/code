    public class DicAsArray<T>
    {
        public DicAsArray()
        {
            _dic = new Dictionary<int, T>();
            _minIndex = 0;
            _maxIndex = -1;
        }
        public void Add(T item)
        {
            _dic[++_maxIndex] = item;
        }
        public T Crop()
        {
            _croppedCount++;
            var item = _dic[_minIndex];
            _dic.Remove(_minIndex++);
            return item;
        }
        public T this[int index]
        {
            get
            {
                var mappedIndex = _croppedCount + index;
                return _dic[mappedIndex];
            }
            set
            {
                var mappedIndex = _croppedCount + index;
                if (mappedIndex > _maxIndex || mappedIndex < _minIndex)
                    throw new IndexOutOfRangeException();
                _dic[mappedIndex] = value;
            }
        }
        private Dictionary<int, T> _dic;
        private int _maxIndex;
        private int _minIndex;
        private int _croppedCount;
    }
