    public class TcpListenerWrapper
    {
        // helper class would not be necessary if base.Active was public, c'mon Microsoft...
        private class TcpListenerActive : TcpListener, IDisposable
        {
            public TcpListenerActive(IPEndPoint localEP) : base(localEP) {}
            public TcpListenerActive(IPAddress localaddr, int port) : base(localaddr, port) {}
            public void Dispose() { Stop(); }
            public new bool Active => base.Active;
        }
        private TcpListenerActive server
    
        public async Task StartAsync(int port, CancellationToken token)
        {
            if (server != null)
            {
                server.Stop();
            }
    
            server = new TcpListenerActive(IPAddress.Any, port);
            server.Start(maxConnectionCount);
            token.Register(() => server.Stop());
            while (server.Active)
            {
                try
                {
                    await ProcessConnection();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    
        private async Task ProcessConnection()
        {
            using (TcpClient client = await server.AcceptTcpClientAsync())
            {
                // handle connection
            }
        }
    }
