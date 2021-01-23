    static void Main(string[] args)
    {
        var host = new ServiceHost(typeof(Service1), new Uri("http://" + System.Net.Dns.GetHostName() + ":8733/DatabaseTransferWcfServiceLibaryMethod/Service1/"));
        ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (smb == null)
        {
            smb = new ServiceMetadataBehavior();
        }
        BasicHttpBinding q = new BasicHttpBinding(BasicHttpSecurityMode.None);
        q.CloseTimeout = new TimeSpan(1, 1, 0);
        q.OpenTimeout = new TimeSpan(1, 1, 0);
        q.ReceiveTimeout = new TimeSpan(1, 1, 0);
        q.SendTimeout = new TimeSpan(1, 1, 0);
        q.AllowCookies = false;
        q.BypassProxyOnLocal = false;
        q.MaxBufferSize = 2147483646;
        q.MaxBufferPoolSize = 2147483646;
        q.MaxReceivedMessageSize = 2147483646;
        q.ReaderQuotas.MaxArrayLength = 2147483646;
        q.ReaderQuotas.MaxBytesPerRead = 2147483646;
        q.ReaderQuotas.MaxDepth = 2147483646;
        q.ReaderQuotas.MaxNameTableCharCount = 2147483646;
        q.ReaderQuotas.MaxStringContentLength = 2147483646;
        host.AddServiceEndpoint(typeof(IService1), q, "");
        smb.HttpGetEnabled = true;
        smb.MetadataExporter.PolicyVersion = PolicyVersion.Default;
        host.Description.Behaviors.Add(smb);
        // ADD ServiceDiscoveryBehavior
        host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
        // COMMENT THIS LINE
        host.AddServiceEndpoint(typeof(IService1), q, "http://" + System.Net.Dns.GetHostName() + ":8733/DatabaseTransferWcfServiceLibaryMethod/Service1/");
        host.AddServiceEndpoint(new UdpDiscoveryEndpoint());
        host.Open();
        var ep = "http://" + System.Net.Dns.GetHostName() + ":8733/DatabaseTransferWcfServiceLibaryMethod/Service1/";
        var binding = new BasicHttpBinding();
        binding.Security.Mode = BasicHttpSecurityMode.None;
        binding.SendTimeout = new System.TimeSpan(0, 1, 30);
        ChannelFactory<IService1> wcfFactory = new ChannelFactory<IService1>(binding, new EndpointAddress(ep));
        IService1 wcf = wcfFactory.CreateChannel();
        System.Net.ServicePointManager.DefaultConnectionLimit = 200;
        Console.WriteLine(wcf.GenerateId(System.Environment.MachineName));
    }
