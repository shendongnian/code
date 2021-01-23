    Connectionclient.BeginConnect("127.0.0.1", 10072, ConnectCallback, 
         Connectionclient);
    ...
    private static void ConnectCallback(IAsyncResult asyncResult)
    {
        TcpClient Connectionclient = (TcpClient)asyncResult.AsyncState;
        Connectionclient.EndConnect(asyncResult);
    }
