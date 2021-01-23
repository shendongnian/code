    class Program
    {
        static void Main(string[] args)
        {
            string urlString = "http://localhost:8081/test";
    
            using (var host = new ServiceHost(typeof(Service), new Uri(urlString)))
            {
                host.AddDefaultEndpoints();
                host.Open();
    
                var obj = new Class1 { PropA = "A", PropB = "B" };
                var header = AddressHeader.CreateAddressHeader("Class1", "Class1", obj);
    
                var binding = new BasicHttpBinding();
                var address = new EndpointAddress(new Uri(urlString), header);
    
                var channel =  ChannelFactory<IService>.CreateChannel(binding, address);
                channel.DoWork();
    
                Console.ReadLine();
            }
        }
    }
    
    [DataContract]
    class Class1
    {
        [DataMember]
        public string PropA { get; set; }
    
        [DataMember]
        public string PropB { get; set; }
    }
    
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        void DoWork();
    }
    
    class Service : IService
    {
        public void DoWork()
        {
            var obj = OperationContext.Current.IncomingMessageHeaders.GetHeader<Class1>("Class1", "Class1");
            Console.WriteLine("PropA: " + obj.PropA);
            Console.WriteLine("PropB: " + obj.PropB);
        }
    }
