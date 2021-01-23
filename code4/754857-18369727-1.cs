    public class DataProviders : IConfigurationSectionHandler
    {
        private static bool _initialized;
        public static List<Provider> _providers;
    
        public object Create(object parent, object configContext, XmlNode section)
        {
            XmlNodeList providers = section.SelectNodes("Provider");
    
            _providers = new List<Provider>();
    
            foreach (XmlNode provider in providers)
            {
                _providers.Add(new Provider
                {
                    Type = provider.Attributes["type"].Value,
                    Alias = provider.Attributes["alias"].Value,
                });
            }
    
            return null;
        }
    
        public static void Init()
        {
            if (!_initialized)
            {
                ConfigurationManager.GetSection("DataProviders");
                _initialized = true;
            }
        }
    
        public static IEnumerable<Provider> GetData(string dataProviderAlias)
        {
            return _providers.Where(p => p.Alias == dataProviderAlias);
        }
    }
    
    public class Provider
    {
        public string Type { get; set; }
        public string Alias { get; set; }
    }
