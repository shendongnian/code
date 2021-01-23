    public interface IGetAppSettings
        {
            NameValueCollection GetAll { get; }
            string MyConnectionString { get; }
        }
    
    public class MyAppSettings : IGetAppSettings
        {
            public NameValueCollection GetAll
            {
                get { return ConfigurationManager.AppSettings; }
            }
    
            public string MyConnectionString
            {
                get
                {
                    var value = ConfigurationManager.ConnectionStrings["MyConnectionString"];
                    return value.ToString();
                }
            } 
        }
