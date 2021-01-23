    static void myServer_OnDataAvailable(TcpServerConnection connection)
    {
        //...Some code...
        connection.sendData(someText);
        Thread.Sleep(2000);
        if (connection.verifyConnected())
        {
            connection.forceDisconnect();
        }
    }
