    public class AppConfiguration
    {
        private static readonly Lazy<AppConfiguration> Instance
            = new Lazy<AppConfiguration>(LoadConfiguration, LazyThreadSafetyMode.PublicationOnly);
        public static AppConfiguration Current
        {
            get { return Instance.Value; }
        }
        public string SystemName { get; private set; }
        public int SystemTimeZone { get; private set; }
        private AppConfiguration() {}
        private static AppConfiguration LoadConfiguration()
        {
            var configuration = new AppConfiguration();
            configuration.LoadFromDatabase();
            return configuration;
        }
        private void LoadFromDatabase()
        {
            using (var db = new AppEntities())
            {
                // Load configuration from DB
                this.SystemName = ""; // Load properties
            }
        }
    }
