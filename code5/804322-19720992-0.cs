    class DataContainer
    {
        readonly byte[] _dataFromWeb;
        DataContainer(byte[] data)
        {
            _dataFromWeb = data;
        }
        public byte this[int index]
        {
            get
            {
                return _dataFromWeb[index];
            }
        }
        public int Size
        {
            get
            {
                return _dataFromWeb.GetUpperBound(0)+1;
            }
        }
    }
