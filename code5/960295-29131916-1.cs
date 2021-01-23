    public class GuidParts
    {
        public GuidParts() { }
        public GuidParts(Guid guid)
        {
            InitFromGuid(guid);
        }
        public GuidParts(string guid)
        {
            var g = Guid.Empty;
            if (Guid.TryParse(guid, out g))
            {
                InitFromGuid(g);
            }
        }
        public Int32 Data1 { get; set; }
        public Int16 Data2 { get; set; }
        public Int16 Data3 { get; set; }
        public Int64 Data4 { get; set; }
        public Guid ToGuid()
        {
            return new Guid(Data1, Data2, Data3, BitConverter.GetBytes(Data4));
        }
        public override string ToString()
        {
            return ToGuid().ToString("B");
        }
        private void InitFromGuid(Guid guid)
        {
            var b = guid.ToByteArray();
            Data1 = BitConverter.ToInt32(b, 0);
            Data2 = BitConverter.ToInt16(b, 4);
            Data3 = BitConverter.ToInt16(b, 6);
            Data4 = BitConverter.ToInt64(b, 8);
        }
    }
