    public class AddressProviderBuilder : IInstanceBuilder
    {
        private readonly IContainer container;
        public AddressProviderBuilder(IContainer container)
        {
            this.container = container;
        }
        public IAddressProvider Build()
        {
            foreach (var provider in this.container.GetAllInstances<IAddressProvider>())
            {
                if (provider.GetAddress(lat, long) != null)
                {
                    return provider;
                }
            }
        }
    }
