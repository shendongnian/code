    public interface IConfiguration
    {
        string SettingA { get; }
    
     
        string SettingB { get; }
    }
    
    
    public class Configuration : IConfiguration
    {
    
        public string SettingA
        {
            get
            {
                return ConfigurationManager.AppSettings["SettingA"];
            }
        }
    
        public string SettingB
        {
            get
            {
                return ConfigurationManager.AppSettings["SettingB"];
            }
        }
    }
