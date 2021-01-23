    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8082);
                
    TcpListener tcpListener = new TcpListener(IPAddress.Any, 8082);           
    
    server = tcpListener.Server;
    server.Bind(ipEndPoint);
    server.Listen(4);
    
    server.BeginAccept(new AsyncCallback(beginConnection), server);
