    public class MyConfig 
    {
        public string BaseAddress 
        { 
            get 
            {
                return string.Format(ConfigurationManager.ApplicationSettings["baseAddressFormat "], System.Net.Dns.GetHostName());
            }
        }
    }
