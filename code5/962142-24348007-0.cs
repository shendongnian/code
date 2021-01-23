    public override int Read(byte[] array, int offset, int count) {
        // Setup state
        while(true) {
            // Process buffer into result (until count achieved or
            // the source stream is finished)
            bytesRead = inflater.Inflate(array, currentOffset, remainingCount);
            if(bytesRead != 0) {
              // break
            } 
            if (inflater.Finished()) {
              // break
            }
            // Read more bytes into buffer: _stream is from the constructor
            int bytes = _stream.Read( buffer, 0, buffer.Length);
            inflater.SetInput(buffer, 0 , bytes);
        }
  
        // ..
    }
