    public static class AppDomainHelper
    {
        public static void Run(Action action)
        {
            var domain = AppDomain.CreateDomain("test domain");
            try
            {
                domain.DoCallBack(new CrossAppDomainDelegate(action));
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }
    }
