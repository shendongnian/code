    public class ConfigurationWrapper
    {
        public virtual string SomeKey
        {
            get
            {
                return ConfigurationManager.AppSettings["SomeKey"];
            }
        }
    }
