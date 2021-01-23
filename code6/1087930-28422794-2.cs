    using(MemoryStream recievedData = new MemoryStream())
    {
        using(NetworkStream networkStream = new NetworkStream(connectedSocket))
        {
            int totalBytesToRead = networkStream.ReadByte();
            // This is your mechanism to find out how many bytes
            // the client wants to send.
            byte[] readBuffer = new byte[1024]; // Up to you the length!
            int totalBytesRead = 0;
            int bytesReadInThisTcpWindow = 0;
            // The length of the TCP window of the client is usually
            // the number of bytes that will be pushed through
            // to your server in one SOCKET.READ method call.
            // For example, if the clients TCP window was 777 bytes, a:
            // int bytesRead = 
            //          networkStream.Read(readBuffer, 0, int.Max);
            //    bytesRead would be 777.
            // If they were sending a large file, you would have to make
            // it up from the many 777s.
           
            // If it were a small file under 777 bytes, your bytesRead
            // would be the total small length of say 500.
            while
            (
                (
                    bytesReadInThisTcpWindow =
                          networkStream.Read(readBuffer, 0, readBuffer.Length)
                ) > 0
            )
                // If the bytesReadInThisTcpWindow = 0 then the client
                // has disconnected or failed to send the promised number
                // of bytes in your Windows server internals dictated timeout
                // (important to kill it here to stop lots of waiting
                // threads killing your server)
            {
                recievedData.Write(readBuffer, 0, bytesReadInThisTcpWindow);
                totalBytesToRead = totalBytesToRead + bytesReadInThisTcpWindow;
            }
            if(totalBytesToRead == totalBytesToRead)
            {
                // We have our data!
            }
        }
    }
