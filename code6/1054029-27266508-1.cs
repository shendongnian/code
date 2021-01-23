    public class MockFooServer
    {
        public Dictionary<string, Func<dynamic>> services = 
            new Dictionary<string,Func<dynamic>>();
        public void AddService(string key, Func<dynamic> factory)
        {
            this.services.Add(key, factory);
        }
    }
