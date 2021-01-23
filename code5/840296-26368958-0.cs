    public class CustomerSyncEngine {
        public CustomerSyncEngine(ILoggingProvider loggingProvider, 
                                  ICrmProvider crmProvider, 
                                  ICacheProvider cacheProvider) { ... }
        public void MethodWithDependencies() {
            loggingProvider.Log();
            crmProvider.Crm();
            cacheProvider.Cache();
        }
    }
