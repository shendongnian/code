    class NulStream : Stream
    {
        public override bool CanRead
        {
            get { return false;  }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override void Flush()
        {
        }
        protected long length;
        public override long Length
        {
            get { return this.length; }
        }
        public override long Position
        {
            get
            {
                return this.length;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.length += count;
        }
    }
    using (var nul = new NulStream())
    {
        xml.Serialize(nul, lst);
        long length = nul.Length;
    }
