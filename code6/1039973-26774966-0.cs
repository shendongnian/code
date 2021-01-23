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
            var item = _dic[_minIndex];
            _dic.Remove(_minIndex--);
            return item;
        }
        public T this[int index]
        {
            get
            {
                return _dic[index];
            }
            set
            {
                if (index > _maxIndex || index < _minIndex)
                    throw new IndexOutOfRangeException();
                _dic[index] = value;
            }
        }
        private Dictionary<int, T> _dic;
        private int _maxIndex;
        private int _minIndex;
    }
