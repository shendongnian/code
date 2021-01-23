    public interface IAppConfig
    {
        Configuration Configuration { get; }
    }
    
    public sealed class AppConfig : IAppConfig
    {
        private readonly Configuration _configuration;
    
        public AppConfiguration()
        {
            _configuration = new Configuration { };
        }
    
        public Configuration Configuration { get { return _configuration; } }
    }
