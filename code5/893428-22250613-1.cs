    using System.Threading.Tasks.Dataflow;
    public class DataflowStreamWriter
    {
        private readonly MemoryStream _stream = new MemoryStream();
        private readonly ActionBlock<byte[]> _block;
        public DataflowStreamWriter()
        {
            _block = new ActionBlock<byte[]>(
                            bytes => _stream.Write(bytes, 0, bytes.Length));
        }
        public void Write(byte[] data)
        {
            _block.Post(data);
        }
    }
