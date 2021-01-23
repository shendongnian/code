    public static class Program
    {
        static Program()
        {
            // Initialize logging
            log4net.Config.XmlConfigurator.Configure();
        }
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        ...
    }
