    var settings = new ChannelTcpListenerConfiguration(
        () => new MicroMessageDecoder(new DataContractSerializer()),
        () => new MicroMessageEncoder(new DataContractSerializer())
        );
     
    var server = new MicroMessageTcpListener(settings);
    server.MessageReceived = OnServerMessage;
    server.Start(IPAddress.Any, 1234);
