    public class SearchProviderFactory {
        private static volatile SearchProviderFactory factory;        
        private static Dictionary<string, Type> providerMap = new Dictionary<string, Type>();
    
        private SearchProviderFactory() {
            // Error on the line below
            providerMap.Add("company_name", Type.GetType("MyApp.CompanySearchProvider"));
            providerMap.Add("job_title", Type.GetType("MyApp.JobTitleSearchProvider"));
        }
    
        public static SearchProviderFactory Instance {
            get {
                if (factory == null) {
    				lock (providerMap)
    				{
    					if (factory == null) {
    						factory = new SearchProviderFactory();
    					}
    				}
                }
    
                return factory;
            }
        }
    }
