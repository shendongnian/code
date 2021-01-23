    public class ProviderFactory
    {
        private List<IProvider> providers;
        public ProviderFactory(IEnumerable<IProvider> providers)
        {
            this.providers = providers.ToList();
        }
    
        public IProvider GetProvider(string searchType)
        {
            // using a switch here would open the factor to modification
            // which would break OCP
            var provider = providers.SingleOrDefault(concretion => concretion.GetType().Name == searchType).ToList();
    
            if (provider == null) throw new Exception("No provider found of that type.  Are you missing an assembly in the RegisterCollection for IProvider?");
    
            return provider;
        }
    
