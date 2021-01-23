    public class ConcurrentStreamWriter : IDisposable
    {
        private readonly MemoryStream _stream = new MemoryStream();
        private readonly BlockingCollection<byte> _buffer = new BlockingCollection<byte>(new ConcurrentQueue<byte>());
        private readonly object _writeBufferLock = new object();
        private Task _flusher;
        private volatile bool _disposed;
        private void FlushBuffer()
        {
            //keep writing to the stream, and block when the buffer is empty
            while (!_disposed)
                _stream.WriteByte(_buffer.Take());
            //when this instance has been disposed, flush any residue left in the ConcurrentStreamWriter and exit
            byte b;
            while (_buffer.TryTake(out b))
                _stream.WriteByte(b);
        }
        public void Write(byte[] data)
        {
            if (_disposed)
                throw new ObjectDisposedException("ConcurrentStreamWriter");
            lock (_writeBufferLock)
                foreach (var b in data)
                    _buffer.Add(b);
            InitFlusher();
        }
        public void InitFlusher()
        {
            //safely create a new flusher task if one hasn't been created yet
            if (_flusher == null)
            {
                Task newFlusher = new Task(FlushBuffer);
                if (Interlocked.CompareExchange(ref _flusher, newFlusher, null) == null)
                    newFlusher.Start();
            }
        }
        public void Dispose()
        {
            _disposed = true;
            if (_flusher != null)
                _flusher.Wait();
            _buffer.Dispose();
        }
    }
