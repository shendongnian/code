    public class PackagePartStream : Stream
    {
        private readonly Stream _stream;
        private static readonly Mutex Mutex = new Mutex(false);
        public PackagePartStream(Stream stream)
        {
            _stream = stream;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            Mutex.WaitOne(Timeout.Infinite, false);
            _stream.Write(buffer, offset, count);
            Mutex.ReleaseMutex();
        }
        public override bool CanRead
        {
            get { return _stream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _stream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return _stream.CanWrite; }
        }
        public override long Length
        {
            get { return _stream.Length; }
        }
        public override long Position
        {
            get { return _stream.Position; }
            set { _stream.Position = value; }
        }
        public override void Flush()
        {
            Mutex.WaitOne(Timeout.Infinite, false);
            _stream.Flush();
            Mutex.ReleaseMutex();
        }
        public override void Close()
        {
            _stream.Close();
        }
        protected override void Dispose(bool disposing)
        {
            _stream.Dispose();
        }
    }
