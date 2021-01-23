    public class Constants
    {
        private static string namespace = null;
        public static string Namespace
        {
            get
            {
                if (namespace == null)
                    namespace = ConfigurationManager.AppSettings["DefaulIP"];
                return namespace;
            }
        }
    }
