    using (ChannelFactory<IService> scf = new ChannelFactory<IService>(new BasicHttpBinding(), "http://localhost:8000/Soap"))
    {
        scf.Endpoint.EndpointBehaviors.Add(new SimpleEndpointBehavior()); // key bit
        IService channel = scf.CreateChannel();
        string s;
        s = channel.EchoWithGet("Hello, world");
        Console.WriteLine("   Output: {0}", s);
    }
