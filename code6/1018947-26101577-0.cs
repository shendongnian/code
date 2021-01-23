    try
    {
        byte[] notify = Encoding.ASCII.GetBytes("Hello");
        stream.Write(notify, 0, notify.Length);
        byte[] notifyResult = new byte[5];
        int bytesRead = stream.Read(notifyResult, 0, 5);
        if (bytesRead == 0)
        {
            // No network error, but server has disconnected
        }
        // Arriving here, notifyResult should contain ASCII "Yeah!" 
    }
    catch (SocketException)
    {
        // Network error
    }
