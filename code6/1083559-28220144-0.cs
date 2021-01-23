    byte[] readBuffer = new byte[32];
    var asyncReader = stream.BeginRead(readBuffer, 0, readBuffer.Length, 
        null, null);
    
    WaitHandle handle = asyncReader.AsyncWaitHandle;
    
    // Give the reader 2seconds to respond with a value
    bool completed = handle.WaitOne(2000, false);
    if (completed)
    {
        int bytesRead = stream.EndRead(asyncReader);
    
        StringBuilder message = new StringBuilder();
        message.Append(Encoding.ASCII.GetString(readBuffer, 0, bytesRead));
    }
