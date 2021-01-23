    private ConcurrentQueue<byte> sendQueue;
    
    private readonly object bufferLock = new object();
    private readonly object streamLock = new object();
    
    public async Task Write(byte[] buffer, int offset, int count)
    {
        bool streamLockTaken = false;
    
        try {
            //attempt to acquire the lock - if lock is currently taken, return immediately
            Monitor.TryEnter(streamLock, ref streamLockTaken);
    
            if(streamLockTaken) //write to stream
            {
              //write to stream
              await stream.WriteAsync(buffer, offset, count);
    
              //flush the buffer
              List<byte> bytes = new List<byte>();
              byte b;
              while(sendQueue.TryDequeue(out b))
                bytes.Add(b);
    
              Write(bytes, 0, bytes.Count);
            }
            else //write to buffer
            {
              lock(bufferLock)
                foreach (var b in buffer)
                  sendQueue.Enqueue(b);
            }
        }
        finally
        {
            if(streamLockTaken)
              Monitor.Exit(streamLock)
        }
    }
