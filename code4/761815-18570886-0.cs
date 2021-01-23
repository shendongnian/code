    public class ConfigValue : List<string>
    {
    }
    public class ConfigKey
    {
        private string s;
        public ConfigKey(string s)
        {
            this.s = s;
        }
        // The implicit operators will allow you to write stuff like:
        // ConfigKey c = "test";
        // string s = c;
        public static implicit operator string(ConfigKey c)
        {
            return c.s;
        }
        public static implicit operator ConfigKey(string s)
        {
            return new ConfigKey(s);
        }
    }
    public class ConfigSection : Dictionary<ConfigKey, ConfigValue>
    {
    }
