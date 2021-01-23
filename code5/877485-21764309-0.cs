    WebHttpBinding myBinding = new WebHttpBinding
                               {
                                   MaxReceivedMessageSize = 2147483647,
                                   MaxBufferSize = 2147483647,
                                   ReaderQuotas =new XmlDictionaryReaderQuotas()
                                   {
                                       MaxArrayLength = 2147483647,
                                       MaxStringContentLength = 2147483647,
                                       MaxDepth = 2147483647,
                                       MaxNameTableCharCount = 2147483647,
                                       MaxBytesPerRead = 2147483647
                                   },
                                   MaxBufferPoolSize = 2147483647,
                                   OpenTimeout = new TimeSpan(0, 0, 10, 0),
                                   ReceiveTimeout = new TimeSpan(0, 0, 10, 0),
                                   TransferMode = TransferMode.Streamed,
                                   CloseTimeout = new TimeSpan(0, 0, 10, 0),
                                   SendTimeout = new TimeSpan(0, 0, 10, 0)
                               };
    if (!ChannelFactories.ContainsKey(endpointName.ToString(CultureInfo.InvariantCulture)))
    {
        
        // Pass the binding created above and the URI into the constructor
        channelFactory = new WebChannelFactory<X>(myBinding, new Uri(endpointName));
        lock (ChannelFactories.SyncRoot)
        {
            ChannelFactories[endpointName.ToString(CultureInfo.InvariantCulture)] = channelFactory;
        }
    }
    else
    {
        channelFactory = ChannelFactories[endpointName.ToString(CultureInfo.InvariantCulture)] as WebChannelFactory<X>;
    }
