    public static final class Configuration
    {
        private static string m_setting1;
        private static bool m_setting2;
        static Configuration()
        {
            // Read all settings
            ...
        }
        public static string Setting1
        {
            get { return m_setting1; }
            set
            {
                if (!m_setting1.Equals(value))
                {
                    m_setting1 = value;
                    StoreSettings();
                }
            }
        }
        public static bool Setting2
        {
            get { rteurn m_setting2; }
            set
            {
                if (!m_setting2 == value)
                {
                    m_setting2 = value;
                    StoreSettings();
                }
            }
        }
