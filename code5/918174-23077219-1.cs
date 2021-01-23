    while (!ssStop)
    {
        TcpClient tcpReceiver = ssTcpListener.AcceptTcpClient(); // this blocks
        ...
    }
