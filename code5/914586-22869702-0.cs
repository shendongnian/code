    public class StackOverflow_22865228
    {
        [ServiceContract]
        public interface ISecureOperation
        {
            [WebGet]
            int Add(int x, int y);
        }
        [ServiceContract]
        public interface IInsecureOperations
        {
            [WebGet]
            int Subtract(int x, int y);
            [WebGet]
            int Multiply(int x, int y);
        }
        public class Service : ISecureOperation, IInsecureOperations
        {
            public int Add(int x, int y) { return x + y; }
            public int Subtract(int x, int y) { return x - y; }
            public int Multiply(int x, int y) { return x * y; }
        }
        public static void StartService()
        {
            string baseAddressHttp = "http://localhost:8000/Service";
            string baseAddressHttps = "https://localhost:8888/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddressHttp), new Uri(baseAddressHttps));
            host.AddServiceEndpoint(typeof(ISecureOperation), new WebHttpBinding(WebHttpSecurityMode.Transport), "")
                .Behaviors.Add(new WebHttpBehavior());
            host.AddServiceEndpoint(typeof(IInsecureOperations), new WebHttpBinding(), "")
                .Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            host.Close();
        }
    }
