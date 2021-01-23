    private static int FreeTcpPort()
        {
            var l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
        [Given(@"a WCF Endpoint")]
        public void GivenAWCFEndpoint()
        {
            //The client 
            RemoteServerController.DefaultPort = FreeTcpPort();
            //The server
            var wcfListener = new ListenerServiceWCF
                {
                    BindingMode = BindingMode.TCP,
                    Uri = new Uri(string.Format("net.tcp://localhost:{0}",
                         RemoteServerController.DefaultPort))
                };
            //The wrapped host is quite a bit of generic code in our common libraries
            WrappedHostServices.Add(wcfListener);
            WrappedHostServices.Start();
        }
