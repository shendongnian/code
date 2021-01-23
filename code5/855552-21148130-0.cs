    public void ReadBytes(
        int numBytes, 
        Action<byte[]> callback, 
        bool doAsync = true)
    {
       if (doAsync)
           ReadBytesAsync(numBytes, callback);
       else
           ReadBytesSync(numBytes, callback);
    }
    private void ReadBytesSync(int numBytes, Action<byte[]> callback)
    {
        var buffer = new byte[numBytes];
        var context = new ReadBytesContext(callback, buffer, 0);
        while (context.ReadSoFar < context.Buffer.Length)
        {
            var bytesRead = _stream.Read(
                context.Buffer, 
                context.ReadSoFar, 
                context.Buffer.Length - context.ReadSoFar);
            context.ReadSoFar += bytesRead;
        }
        context.Callback(context.Buffer);
    }
    private void ReadBytesAsync(int numBytes, Action<byte[]> callback)
    {
        // Works as your current ReadBytes, which is async
    }
