    public class AppSettings
    {
        public static int MinPasswordLength
        {
            get
            {
                //  Recommended minimum password length.
                //  See https://www.owasp.org/index.php/Password_length_%26_complexity
                int min = 8;
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["app.minPasswordLength"]))
                {
                    min = int.Parse(ConfigurationManager.AppSettings["app.minPasswordLength"]);
                }
                return min;
            }
        }
        /* ... */
        public static string Find(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
        }
    }
