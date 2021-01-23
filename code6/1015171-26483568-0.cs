    var ep = "http://" + System.Net.Dns.GetHostName() + ":8732/DatabaseTransfer/Service1/";
    var binding = new BasicHttpBinding();
    binding.Security.Mode = BasicHttpSecurityMode.None;
    binding.SendTimeout = new System.TimeSpan(0, 1, 30);
    ChannelFactory<IService1> wcfFactory = new ChannelFactory<IService1>(binding, new EndpointAddress(ep));
    IService1 wcf = wcfFactory.CreateChannel();
