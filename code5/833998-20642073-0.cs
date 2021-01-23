    try
    {
        if (client.Client.Poll(1000, SelectMode.SelectRead) && client.Client.Available == 0)
        {
            isConnected = false;
        }
    }
    catch (Exception)
    {
        //  If an exception is thrown, then the connection is closed
        isConnected = false;
    }
