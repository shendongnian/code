    public class GuidParts
    {
        private byte[] _bytes;
        public GuidParts() : this(Guid.Empty)
        {
        }
        public GuidParts(Guid guid)
        {
            InitFromGuid(guid);
        }
        public GuidParts(string str)
        {
            var guid = Guid.Empty;
            if (Guid.TryParse(str, out guid))
            {
                InitFromGuid(guid);
            }
        }
        public Int32 Data1 { get; set; }
        public Int16 Data2 { get; set; }
        public Int16 Data3 { get; set; }
        public Int64 Data4
        {
            get { return BitConverter.ToInt64(_bytes, 0); }
            set { _bytes = BitConverter.GetBytes(value); } 
            
        }
        public byte[] Data4Bytes
        {
            get { return _bytes; }
            set { _bytes = SafeCopy(value, 8); }
        }
        public Int16 Data4High
        {
            get { return BitConverter.ToInt16(_bytes, 0); }
            set { Buffer.BlockCopy(BitConverter.GetBytes(value), 0, _bytes, 0, 2); }
        }
        public Int16 Data4HighReverse
        {
            get { return BitConverter.ToInt16(ReverseArray(_bytes), 0); }
            set { Buffer.BlockCopy(ReverseArray(BitConverter.GetBytes(value)), 0, _bytes, 0, 2); }
        }
        public Int64 Data4Reverse
        {
            get { return BitConverter.ToInt64(ReverseArray(_bytes), 0); }
            set { _bytes = ReverseArray(BitConverter.GetBytes(value)); }
        }
        public Guid ToGuid()
        {
            return new Guid(Data1, Data2, Data3, _bytes);
        }
        public override string ToString()
        {
            return ToGuid().ToString("B");
        }
        #region private
        private void InitFromGuid(Guid guid)
        {
            var b = guid.ToByteArray();
            Data1 = BitConverter.ToInt32(b, 0);
            Data2 = BitConverter.ToInt16(b, 4);
            Data3 = BitConverter.ToInt16(b, 6);
            _bytes = new[] { b[8], b[9], b[10], b[11], b[12], b[13], b[14], b[15] };
        }
        // Because Array.Reverse modifies the original array and returns void. Yuck.
        private T[] ReverseArray<T>(T[] input) where T : new()
        {
            int from = input.Length, to = 0;
            T[] reversed = new T[from];
            while (from-- > 0) reversed[to++] = input[from];
            return reversed;
        }
        private T[] SafeCopy<T>(T[] input, int count) where T : new()
        {
            T[] copied = new T[count];
            int position = 0, length = input.Length;
            while (position < length) copied[position] = input[position++];
            return copied;
        }
        #endregion
    }
