     public interface IConfigurationReader
    {
        T Read<T>(string configKey);
    }
    
    public class Configuration
    {
        private readonly IConfigurationReader _reader;
    
        public Configuration(IConfigurationReader reader)
        {
            _reader = reader;
        }
    
        public string Path
        {
            get
            {
                var path = _reader.Read<string>("Path");
                return path;
            }
        }
    }
    
    public class ApplicationConfigFileReader : IConfigurationReader
    {
        public T Read<T>(string configKey)
        {
            var settingValue = System.Configuration.ConfigurationManager.AppSettings[configKey];
            return (T)Convert.ChangeType(settingValue, typeof(T));
        }
    }
    
    //sample usage
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationReader reader = new ApplicationConfigFileReader();
            var config = new Configuration(reader);
            Console.WriteLine(config.Path);
            Console.ReadKey();
        }
    }
