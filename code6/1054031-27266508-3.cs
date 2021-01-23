    public class MockFooServer
    {
        public Dictionary<string, Func<DataProvider>> services = 
            new Dictionary<string, Func<DataProvider>>();
        public void AddService<T>(string key, Func<T> factory) where T : DataProvider
        {
            this.services.Add(key, factory as Func<DataProvider>);
        }
    }
