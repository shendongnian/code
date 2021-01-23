    public class MyConfig 
    {
        public string BaseAddress 
        { 
            get 
            {
                return string.Format(ConfigurationManager.AppSettings["baseAddressFormat "], System.Net.Dns.GetHostName());
            }
        }
    }
