    string serviceName = FullMoon ? "Service1" : "Service2";
    
    var channelFactory = new ChannelFactory<IServiceInterface>(serviceName);
    
    var proxy = channelFactory.CreateChannel();
    
    proxy.SomeServiceCall();
    
    channelFactory.Close();
