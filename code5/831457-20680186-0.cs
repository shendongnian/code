    private static Dispatcher dispatcher;
    public void Initialize()
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            this.host = new ServiceHost(typeof(Printer), new[] { new Uri("net.pipe://localhost") });
            this.host.AddServiceEndpoint(typeof(IConnector), new NetNamedPipeBinding(), "GetPdfVersion");
            this.host.Open();
        }
