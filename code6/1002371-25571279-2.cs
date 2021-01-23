    public class ArrayQueue<T>
    {
        private T[] _array;
        private int _in, _out, _count, _length;
        public ArrayQueue(int length)
        {
            _length = length;
            _array = new T[length];
        }
        public void Enqueue(T item)
        {
            if (_count == _length) {
                throw new ApplicationException("Queue is full");
            }
            _array[_in] = item;
            _in = (_in + 1) % _length;
            _count++;
        }
        public T Dequeue()
        {
            if (_count == 0) {
                throw new ApplicationException("Queue is empty");
            }
            T temp = _array[_out];
            _out = (_out + 1) % _length;
            _count--;
            return temp;
        }
        public int Count { get { return _count; } }
        public T[] Array { get { return _array; } }
        public T this[int index]
        {
            get
            {
                if (!IsIndexValid(index)) {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (!IsIndexValid(index)) {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }
        public bool IsIndexValid(int index)
        {
            if (index < 0 || index >= _length) {
                return false;
            }
            if (_count == _length) {
                return true;
            }
            return _out > _in
                ? index < _in || index >= _out
                : index >= _out && index < _in;
        }
    }
