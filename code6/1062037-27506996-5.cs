    public class Constants
    {
        private static string _namespace = null;
        public static string Namespace
        {
            get
            {
                if (_namespace == null)
                    _namespace = ConfigurationManager.AppSettings["DefaulIP"];
                return _namespace;
            }
        }
    }
