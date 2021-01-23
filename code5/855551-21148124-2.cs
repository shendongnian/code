    private IEnumerator<int> ReadBytesEnumerator(AsyncEnumerator<byte[]> ae, int numbytes)
    {
       byte [] buffer = new byte[numbytes];
       int totalBytes = 0;
       while(totalBytes < numbytes)
       {
         _stream.BeginRead(buffer , totalBytes , numbytes - totalBytes , ae.End(), null);
    
         yield return 1;
    
         totalBytes +=_stream.EndRead(ae.DequeueResult());
    
       }
       ae.Result = buffer;
    }
    
    public IAsyncResult BeginReadBytes(int numBytes, AsyncCallback callback, object state)
    {
       AsyncEnumerator<byte []> ae = new AsyncEnumerator<byte[]>();
       return ae.BeginExecute(ReadBytesEnumerator(ae, numBytes), callback, state);
    }
    
    public byte [] EndReadBytes(IAsyncResult result)
    {
      return AsyncEnumerator<byte[]>.FromAsyncResult(result).EndExecute();
    }
