        private string _result;
    private readonly IClientWcfServiceChannel _client;
        
    public ChanFacWcfServiceMainPageViewModel()
    {
        var f = new ChannelFactory<IClientWcfServiceChannel>(new BasicHttpBinding(),
            new EndpointAddress("http://localhost:50001/WcfService.svc"));
        _client = f.CreateChannel();
        FireCommand = new RelayCommand(Execute);   
    }
    private void Callback(IAsyncResult ar)
    {
        var context = ar.AsyncState as SynchronizationContext;
        if (context == null)
        {
            throw new Exception("wtf");
        }
        var result2 = _client.EndCreateParentData(ar);
        context.Post(o => { Result = result2.ToString(); }, null);
    }
    private void Execute()
    {
        _client.BeginCreateParentData(ClientWcfServiceStartUpMode.StartUpLater, Callback, SynchronizationContext.Current);
    }
