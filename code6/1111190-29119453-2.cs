    public static splashScreen GetInstance()
    {
            if (m_instance == null)
            {
                lock (m_instanceLock)
                {
                    if (m_instance == null)
                    {
                       m_instance = new splashScreen();
                    }
                }
            }
            return m_instance;
    }
