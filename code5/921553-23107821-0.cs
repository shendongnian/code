    class Server : MarshalByRefObject, ServerInterface
    {
        public Server()
        {
        }
    
        public Server(bool local)
        {
           Listener();
        }
    
        private void Listener()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
    
            while (offline == false)
            {
                TcpClient client = listener.AcceptTcpClient();
            }
        }
     }
    ...
    TcpChannel channel = new TcpChannel(5002);
    ChannelServices.RegisterChannel(channel, false);
    RemotingConfiguration.RegisterWellKnownServiceType(typeof(Server),
            "Server", WellKnownObjectMode.SingleCall);
    
    Server s = new Server(true);
