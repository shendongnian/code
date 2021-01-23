    ...
    private static PinnableBufferCache _WriteBufferCache = new PinnableBufferCache("System.Net.HttpWebRequest", CachedWriteBufferSize);
    ...
    // Return the buffer to the pinnable cache if it came from there.   
    internal void FreeWriteBuffer()
    {
      if (_WriteBufferFromPinnableCache)
      {
        _WriteBufferCache.FreeBuffer(_WriteBuffer);
        _WriteBufferFromPinnableCache = false;
      }
      _WriteBufferLength = 0;
      _WriteBuffer = null;
    }
    ...
