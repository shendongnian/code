    public sealed class RangeCheckedByteArray
    {
        public RangeCheckedByteArray(int size)
        {
            _data = new byte[size];
        }
        public byte this[int index] // This indexer ensures that values are checked.
        {
            get
            {
                return _data[index];
            }
            set // Nobody can set an element's value without coming through here.
            {
                _data[index] = (byte)(value%7);
            }
        }
        private readonly byte[] _data;
    }
