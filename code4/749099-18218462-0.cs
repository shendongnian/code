    public class ConfigurationManager
    {
        public string UploadPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["UploadPath"];
            }
        }
    }
