    public class ArrayBlocksQueue<T>
    {
        private T[] _array;
        private int _in, _out, _count, _length, _blockSize;
        public ArrayBlocksQueue(int maxBlocks, int blockSize)
        {
            _length = maxBlocks * blockSize;
            _blockSize = blockSize;
            _array = new T[_length];
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
            block.CopyTo(_array, _in);
            _in = (_in + _blockSize) % _length;
            _count += _blockSize;
        }
        public T[] Dequeue()
        {
            if (_count == 0) {
                throw new ApplicationException("Queue is empty");
            }
            T[] temp = new T[_blockSize];
            System.Array.Copy(_array, _out, temp, 0, _blockSize);
            _out = (_out + _blockSize) % _length;
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
