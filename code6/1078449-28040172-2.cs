    public class ServiceClientFactory : IServiceClientFactory
    {
        public IServiceClient CreateInstance()
        {
            return new ServiceClient();
        }
    }
