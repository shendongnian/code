    if (connectRetryAttempts > 0)
    {
        --connectRetryAttempts;
        Timer delay = null;
        delay = new Timer(_=> 
        {
           tcpClient.BeginConnect(EndPoint.Address, EndPoint.Port, ConnectCallback, null);
           delay.Dispose();
        }, connectRetryDelay * 1000, Timeout.Infinite);
    }
