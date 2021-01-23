    Socket myAsyncConnectSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
    myAsyncConnectSocket.ReceiveTimeout = 10;
    myAsyncConnectSocket.SendTimeout = 10;
    int connectTimeout = 10;
    var asyncResult = myAsyncConnectSocket.BeginConnect(
        new IPEndPoint(IPAddress.Loopback, 57005), null, null);
    bool timeOut = true;
    if (asyncResult.AsyncWaitHandle.WaitOne(connectTimeout))
    {
        timeOut = false;
        Console.WriteLine("Async Connected");
        try
        {
            myAsyncConnectSocket.Send(Encoding.ASCII.GetBytes("Test 1 2 3"));
            Console.WriteLine("Sent");
            byte[] buffer = new byte[128];
            myAsyncConnectSocket.Receive(buffer);
            Console.WriteLine("Received: {0}", Encoding.ASCII.GetString(buffer));
        }
        catch (SocketException se)
        {
            if (se.SocketErrorCode == SocketError.TimedOut) timeOut = true;
            else throw;
        }
    }
    Console.WriteLine("Timeout occured: {0}", timeOut);
