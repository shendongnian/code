    public sealed class MyStream : Stream
    {
        private readonly MemoryStream underlyingStream = new MemoryStream();
        private readonly AutoResetEvent waitHandle = new AutoResetEvent(false);
        
        public int Timeout { get; set; }
        public MyStream()
        {
            Timeout = 5000;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            // Write to the stream and notify any waiting threads
            underlyingStream.Write(buffer, offset, count);
            waitHandle.Set();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytes;
            while ((bytes = underlyingStream.Read(buffer, offset, count)) == 0)
            {
                // 0 bytes read (end of stream), wait Timeout ms for someone to write
                if (!waitHandle.WaitOne(Timeout))
                {
                    return 0;
                }
            }
            return bytes;
        }
        
        // TODO other mandatory methods
    }
