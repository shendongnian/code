    private void Read(IAsyncResult ar)
    {
    
        int sizeOfReceivedData = ConnectionSocket.EndReceive(ar);
        if (sizeOfReceivedData > 0)
        {
            int start = 0, end = dataBuffer.Length - 1;
    
            var bufferList = dataBuffer.ToList();
    
            bool endIsInThisBuffer = dataBuffer.Contains(255); // 255 = end
            if (endIsInThisBuffer)
            {
                end = bufferList.IndexOf(255);
                end--; // we dont want to include this byte
            }
    
            bool startIsInThisBuffer = dataBuffer.Contains(0); // 0 = start
            if (startIsInThisBuffer)
            {
                var zeroPos = bufferList.IndexOf(0);
                if (zeroPos < end) // we might be looking at one of the bytes in the end of the array that hasn't been set
                {
                    start = zeroPos;
                    start++; // we dont want to include this byte
                }
            }
    
            dataString.Append(Encoding.UTF8.GetString(dataBuffer, start, (end - start) + 1));
    
            if (endIsInThisBuffer)
            {
                var data = dataString.ToString();
                OnDataReceived(new DataReceivedEventArgs(data.Length, data));
    
                // Testing to see if readable
                ReadRecievedData(data);
    
                dataString = new StringBuilder();
            }
    
            Listen();
    	}
        else // the socket is closed
        {
            if (Disconnected != null)
                Disconnected(this, EventArgs.Empty);
        }
    }
