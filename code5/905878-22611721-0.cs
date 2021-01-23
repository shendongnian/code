    internal class NDISQueryOid
    {
        protected const int NDISUIO_QUERY_OID_SIZE = 12;
        protected byte[] m_data;
        public int Size { get; private set; }
        public NDISQueryOid(byte[] data)
        {
            int extrasize = data.Length;
            Size = 8 + extrasize;
            m_data = new byte[Size];
            Buffer.BlockCopy(data, 0, m_data, DataOffset, data.Length);
        }
        public NDISQueryOid(int extrasize)
        {
           Size = NDISUIO_QUERY_OID_SIZE + extrasize;
            m_data = new byte[Size];
        }
        protected const int OidOffset = 0;
        public uint Oid
        {
            get { return BitConverter.ToUInt32(m_data, OidOffset); }
            set
            {
                byte[] bytes = BitConverter.GetBytes(value);
                Buffer.BlockCopy(bytes, 0, m_data, OidOffset, 4);
            }
        }
        protected const int ptcDeviceNameOffset = OidOffset + 4;
        public unsafe byte* ptcDeviceName
        {
            get
            {
                return (byte*)BitConverter.ToUInt32(m_data, ptcDeviceNameOffset);
            }
            set
            {
                byte[] bytes = BitConverter.GetBytes((UInt32)value);
                Buffer.BlockCopy(bytes, 0, m_data, ptcDeviceNameOffset, 4);
            }
        }
        protected const int DataOffset = ptcDeviceNameOffset + 4;
        public byte[] Data
        {
            get
            {
                byte[] b = new byte[Size - DataOffset];
                Array.Copy(m_data, DataOffset, b, 0, Size - DataOffset);
                return b;
            }
            set
            {
                Size = 8 + value.Length;
                m_data = new byte[Size];
                Buffer.BlockCopy(value, 0, m_data, DataOffset, value.Length);
            }
        }
        public byte[] getBytes()
        {
            return m_data;
        }
        public static implicit operator byte[](NDISQueryOid qoid)
        {
            return qoid.m_data;
        }
    }
