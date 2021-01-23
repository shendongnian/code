    class Program
    {
        static void Main(string[] args)
        {
            Uri[] BaseAddresses = new Uri[] { new Uri("http://10.200.32.98:9999") };
            using (var host = new ServiceHost(typeof(Service), BaseAddresses))
            {
                host.AddServiceEndpoint(typeof(Service), new BasicHttpBinding() { HostNameComparisonMode = HostNameComparisonMode.Exact }, "");
                host.Open();
                Console.ReadLine();
            }
        }
    }
    [ServiceContract]
    class Service
    {
        [OperationContract]
        public void doit()
        {
        }
    }
