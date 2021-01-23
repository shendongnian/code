    private readonly object writeLock = new Object();
    
    public async void Write(byte[] buffer, int offset, int count)
    {
       lock (writeLock)
       {
          await stream.WriteAsync(buffer, offset, count);
       }
    }
