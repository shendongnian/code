    using Starksoft.Aspen.Proxy;
        Socks5ProxyClient proxyClient = new Socks5ProxyClient(
            socks5Proxy.Host, socks5Proxy.Port, 
            socks5Proxy.Username, socks5Proxy.Password);
        TcpClient client = proxyClient.CreateConnection(destination.Host, 
            destination.Port);
        NetworkStream stream = client.GetStream();
