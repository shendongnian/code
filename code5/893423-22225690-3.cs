    private readonly ConcurrentQueue<byte> _bufferQueue = new ConcurrentQueue<byte>();
    private readonly object _bufferLock = new object();
    private readonly object _streamLock = new object();
    private readonly MemoryStream stream = new MemoryStream();
    public async Task Write(byte[] data, int offset, int count)
    {
        bool streamLockTaken = false;
        try
        {
            //attempt to acquire the lock - if lock is currently taken, return immediately
            Monitor.TryEnter(_streamLock, ref streamLockTaken);
            if (streamLockTaken) //write to stream
            {
                //write data to stream and flush the buffer
                List<byte> bufferedData = new List<byte>();
                byte b;
                while (_bufferQueue.TryDequeue(out b))
                    bufferedData.Add(b);
                await stream.WriteAsync(data, offset, count);
                await stream.WriteAsync(bufferedData.ToArray(), offset, bufferedData.Count);
            }
            else //write to buffer
            {
                lock (_bufferLock)
                    foreach (var b in data)
                        _bufferQueue.Enqueue(b);
            }
        }
        finally
        {
            if (streamLockTaken)
                Monitor.Exit(_streamLock);
        }
    }
