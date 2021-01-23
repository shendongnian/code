        private static splashScreen m_instance = null;
        private static object m_instanceLock = new object();
        public static splashScreen GetInstance()
        {
            lock (m_instanceLock)
            {
                if (m_instance == null)
                {
                    m_instance = new splashScreen();
                }
            }
            return m_instance;
        }
