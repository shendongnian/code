    using Starksoft.Aspen.Proxy;
        Client = new TcpClient();
        Client.Connect(EndPoint);
        Socks5ProxyClient SocksProxyClient = new Socks5ProxyClient(
            Socks5ProxyHost, Socks5ProxyPort, 
            Socks5ProxyUsername, Socks5ProxyPassword);
        SocksProxyClient.TcpClient = Client;
        SocksProxyClient.CreateConnectionAsyncCompleted += (s, a) =>
        {
            NetworkStream = Client.GetStream();
        };
        SocksProxyClient.CreateConnectionAsync(DestinationServer.Host, DestinationServer.Port);
