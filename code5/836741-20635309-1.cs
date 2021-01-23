    void Main()
    {
        var buffer = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();
        using (var underlying = new MemoryStream(buffer))
        using (var partialStream = new PartialStream(underlying, 64, 32))
        {
            var temp = new byte[1024]; // too much, ensure we don't read past window end
            partialStream.Read(temp, 0, temp.Length);
            temp.Dump();
            // should output 64-95 and then 0's for the rest (64-95 = 32 bytes)
        }
    }
    
    public class PartialStream : Stream
    {
        private readonly Stream _UnderlyingStream;
        private readonly long _Position;
        private readonly long _Length;
    
        public PartialStream(Stream underlyingStream, long position, long length)
        {
            if (!underlyingStream.CanRead || !underlyingStream.CanSeek)
                throw new ArgumentException("underlyingStream");
    
            _UnderlyingStream = underlyingStream;
            _Position = position;
            _Length = length;
            _UnderlyingStream.Position = position;
        }
    
        public override bool CanRead
        {
            get
            {
                return _UnderlyingStream.CanRead;
            }
        }
    
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
    
        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }
    
        public override long Length
        {
            get
            {
                return _Length;
            }
        }
    
        public override long Position
        {
            get
            {
                return _UnderlyingStream.Position - _Position;
            }
    
            set
            {
                _UnderlyingStream.Position = value + _Position;
            }
        }
    
        public override void Flush()
        {
            throw new NotSupportedException();
        }
    
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    return _UnderlyingStream.Seek(_Position + offset, SeekOrigin.Begin) - _Position;
    
                case SeekOrigin.End:
                    return _UnderlyingStream.Seek(_Length + offset, SeekOrigin.Begin) - _Position;
    
                case SeekOrigin.Current:
                    return _UnderlyingStream.Seek(offset, SeekOrigin.Current) - _Position;
    
                default:
                    throw new ArgumentException("origin");
            }
        }
    
        public override void SetLength(long length)
        {
            throw new NotSupportedException();
        }
    
        public override int Read(byte[] buffer, int offset, int count)
        {
            long left = _Length - Position;
            if (left < count)
                count = (int)left;
            return _UnderlyingStream.Read(buffer, offset, count);
        }
    
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }
