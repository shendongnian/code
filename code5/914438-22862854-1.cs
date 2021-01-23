    public class ProviderFactory : IProviderFactory
    {
        private readonly Dictionary<string, Type> providerTypes;
        private readonly Container container;
        public ProviderFactory(Dictionary<string, Type> providerTypes, 
            Container container) {
            this.providerTypes = providerTypes;
            this.container = container;
        }
        public IProvider CreateProvider(string name) {
            return (IProvider)this.container.Resolve(this.providerTypes[name]);
        }
    }
