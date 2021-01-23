    class StreamInterceptor : Stream
    {
      public Stream DecoratedInstance { get; set; }
      public event Action<byte[]> BytesRead;
      public event Action<byte[]> BytesWritten;
      public StreamInterceptor( Stream instance )
      {
        if ( instance == null ) throw new ArgumentNullException("instance");
        this.DecoratedInstance = instance ;
        return ;
      }
      public override bool CanRead
      {
        get { return DecoratedInstance.CanRead; }
      }
      public override bool CanSeek
      {
        get { return DecoratedInstance.CanSeek; }
      }
      public override bool CanWrite
      {
        get { return DecoratedInstance.CanWrite; }
      }
      public override void Flush()
      {
        DecoratedInstance.Flush();
        return;
      }
      public override long Length
      {
        get { return DecoratedInstance.Length; }
      }
      public override long Position
      {
        get { return DecoratedInstance.Position; }
        set { DecoratedInstance.Position = value; }
      }
      public override int Read( byte[] buffer , int offset , int count )
      {
        int bytesRead = DecoratedInstance.Read(buffer, offset, count);
        // raise the bytes read event
        byte[] temp = new byte[bytesRead];
        Array.Copy(buffer,offset,temp,0,bytesRead);
        BytesRead(temp);
        return bytesRead;
      }
      public override long Seek( long offset , SeekOrigin origin )
      {
        return DecoratedInstance.Seek(offset, origin);
      }
      public override void SetLength( long value )
      {
        DecoratedInstance.SetLength(value);
        return;
      }
      public override void Write( byte[] buffer , int offset , int count )
      {
        // raise the bytes written event
        byte[] temp = new byte[count];
        Array.Copy(buffer,offset,temp,0,count);
        BytesWritten(temp);
        DecoratedInstance.Write(buffer, offset, count);
        return;
      }
    }
