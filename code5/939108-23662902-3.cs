    static class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            log4net.Util.SystemInfo.NullText = String.Empty;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Logger.Debug("Service Starting");
            using (var container = new UnityContainer())
            {
                var debugMode = args.Contains("--debug", StringComparer.InvariantCultureIgnoreCase);
                BaseUnityConfiguration.Configure(container, debugMode);
                LogManager.GetRepository().Properties["ClientLoggerFactory"] = container.Resolve<Func<ClientLoggerClient>>();
                //...
