    Public static class DataAccess
    {
        private static readonly string DbfactoryName=   ConfigurationManager.AppSettings.Get("factoryName");
        private static readonly IRepoFactory factory = RepoFactories.GetFactory(DbfactoryName);
        public static ITransactionRepositry transRepo
        {
            get {return factory.TransRepo;}
        }
        public static IAccountRepository accountRepo
        {
            get {return factory.AccountRepo;}
        }
    }
