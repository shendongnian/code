    BasicHttpBinding binding = new BasicHttpBinding();
    binding.MaxReceivedMessageSize = Int32.Max;
    binding.SendTimeOut = new Timespan();
    binding.ReceiveTimeout = new TimeSpan();
    
    XmlDictionaryReaderQuotas quotas = new XmlDictionaryReaderQuotas();
    quotas.MaxArrayLength = Int32.Max;
    binding.ReaderQuotas = quotas;
    this.ProxyFactory = new ChannelFactory<IProxyServiceChannel>(binding);
