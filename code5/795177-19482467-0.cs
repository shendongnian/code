    public class ServiceStreamReaderStateObject
    {
        public const int BufferSize = 1024;
        public byte[] Buffer { get; set; }
        public int TotalRead { get; set; }
        public ServiceStreamReaderStateObject()
        {
            Buffer = new byte[BufferSize];
        }
    
