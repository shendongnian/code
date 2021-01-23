    BasicHttpBinding binding = new BasicHttpBinding();
    binding.SendTimeout = new TimeSpan(TimeSpan.TicksPerMillisecond * 5000);
    
    EndpointAddress address = new EndpointAddress(uri);
    var factory = new ChannelFactory<InformedMotion.Engine.wsMotion.ISync2Channel>(binding, address);
    wcf = factory.CreateChannel();
