    public class ArrayBlocksQueue<T>
    {
        private T[] _array;
        private int _in, _out, _count, _length, _blockSize;
        public ArrayBlocksQueue(int length, int blockSize)
        {
            _length = length;
            _blockSize = blockSize;
            _array = new T[length];
        }
        public void Enqueue(params T[] block)
        {
            if (block == null) {
                throw new ArgumentNullException();
            }
            if (block.Length != _blockSize) {
                throw new ArgumentException("Data does not have required block size.");
            }
            if (_count + _blockSize > _length) {
                throw new ApplicationException("Queue is full");
            }
            for (int i = 0; i < _blockSize; i++) {
                _array[_in] = block[i];
                _in = (_in + 1) % _length;
            }
            _count += _blockSize;
        }
        public T[] Dequeue()
        {
            if (_count == 0) {
                throw new ApplicationException("Queue is empty");
            }
            T[] temp = new T[_blockSize];
            for (int i = 0; i < _blockSize; i++) {
                temp[i] = _array[_out];
                _out = (_out + 1) % _length;
            }
            _count -= _blockSize;
            return temp;
        }
        public int Count { get { return _count; } }
        public int BlockCount { get { return _count / _blockSize; } }
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
            return _out > _in ? index < _in || index >= _out : index >= _out && index < _in;
        }
    }
