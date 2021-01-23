    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    internal struct DataTypeParam
    {
        public int dtType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        private byte[] dtUnion;
        public int cInt
        {
            get { return BitConverter.ToInt32(dtUnion, 0); }
            set { dtUnion = BitConverter.GetBytes(value); }
        }
        public double cFloat
        {
            get { return BitConverter.ToDouble(dtUnion, 0); }
            set { dtUnion = BitConverter.GetBytes(value); }
        }
    };
