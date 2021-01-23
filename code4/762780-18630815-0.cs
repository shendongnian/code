    delegate Task<Stream> AsyncRangeDownloader(ulong start, ulong? end);
    class StreamingRandomAccessStream : IRandomAccessStream
    {
        private readonly AsyncRangeDownloader _downloader;
        private readonly ulong _size;
        public StreamingRandomAccessStream(Stream startStream, AsyncRangeDownloader downloader, ulong size)
        {
            if (startStream != null)
                _stream = startStream.AsInputStream();
            _downloader = downloader;
            _size = size;
        }
        private IInputStream _stream;
        private ulong _requestedPosition;
        public void Dispose()
        {
            if (_stream != null)
                _stream.Dispose();
        }
        public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
        {
            return AsyncInfo.Run<IBuffer, uint>(async (cancellationToken, progress) =>
            {
                progress.Report(0);
                if (_stream == null)
                {
                    var netStream = await _downloader(_requestedPosition, null);
                    _stream = netStream.AsInputStream();
                }
                var result = await _stream.ReadAsync(buffer, count, options).AsTask(cancellationToken, progress);
                return result;
            });
        }
        public void Seek(ulong position)
        {
            if (_stream != null)
                _stream.Dispose();
            _requestedPosition = position;
            _stream = null;
        }
        public bool CanRead { get { return true; } }
        public bool CanWrite { get { return false; } }
        public ulong Size { get { return _size; } set { throw new NotSupportedException(); } }
        public IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer) { throw new NotSupportedException(); }
        public IAsyncOperation<bool> FlushAsync() { throw new NotSupportedException(); }
        public IInputStream GetInputStreamAt(ulong position) { throw new NotSupportedException(); }
        public IOutputStream GetOutputStreamAt(ulong position) { throw new NotSupportedException(); }
        public IRandomAccessStream CloneStream() { throw new NotSupportedException(); }
        public ulong Position { get { throw new NotSupportedException(); } }
    }
