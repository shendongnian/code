    void SendData(byte[] data)
    {
        // get the 4 bytes of a int value.
        byte[] dataLength = BitConverter.GetBytes(data.Lenght);
        // write the length to the stream.
        stream.Write(dataLength, 0, dataLength.Length);
        // write the data bytes.
        stream.Write(data, 0, data.Length);
    }
    void Receive()
    {
        // read 4 bytes from the stream.
        ReadBuffer(buffer, 4);
        // convert those 4 bytes to an int.
        int dataLength = BitConverter.ToInt32(buffer, 0);
        // read bytes with dataLength as count.
        ReadBuffer(buffer, dataLength);    
    }
    // read until the right amount of bytes are read.
    void ReadBuffer(byte[] buffer, int length)
    {
        int i = 0;
        int bytesNeeded = length;
        int bytesReceived = 0;
        do
        {
            //read byte from client
            int bytesRead = stream.Read(buffer, bytesReceived, bytesNeeded-bytesReceived);
            bytesReceived += bytesRead;
            // merge byte array to another byte array
        } while (bytesReceived < bytesNeeded);   //  <- you should do this async.
    }
