    labelConnectionState.Text = "Connecting";
    Connectionclient.BeginConnect("..", 43594, ConnectCallback,  Connectionclient);
    ...
    private static void ConnectCallback(IAsyncResult asyncResult)
    {
        try
        {
            TcpClient Connectionclient = (TcpClient) asyncResult.AsyncState;
            Connectionclient.EndConnect(asyncResult);
            labelConnectionState.Text = "Connected";
        }
        catch (SocketException socketException)
        {
            labelConnectionState.Text = "Server unavailable";
        }
    }
