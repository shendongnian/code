    public class DefaultNavigationService : NavigationService
    {
        public Dictionary<string, Type> Configuration
        {
            get;
            private set;
        }    
        public DefaultNavigationService() : base()
        {
            Configuration = new Dictionary<string, Type>();            
        }
        public new void Configure(string key, Type pageType)
        {
            Configuration.Add(key, pageType);
            base.Configure(key, pageType);
        }
    }
