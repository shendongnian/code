    class MySingleton
    {
        private static MySingleton _instance;
    
        private MySingleton()
        {
        }
        private MySingleton(params object[] parameters)
        {
            // assign parameters
        }
        public static MySingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("not created");
                }
                return _instance;
            }
        }
    
        public static void Create(params object[] parameters)
        {
            if (_instance != null)
            {
                return;
            }
    
            _instance = new MySingleton(parameters);
        }
    }
