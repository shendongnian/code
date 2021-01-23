    public class Proxy : IClient
    {
        private readonly IClient _client;
        public Proxy(IClient client)
        {
            _client = client;
            Console.WriteLine("ProxyClient: Initialized");
        }
    
        public string GetData()
        {
            return _client.GetData();
        }
    }
