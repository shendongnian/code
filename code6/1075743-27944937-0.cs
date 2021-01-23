    class DatabaseManagement
    {
        private static DatabaseManagement _instance;
        public static DatabaseManagement Inst {
            // Return _instance, but make it a new DatabaseManagement() if null:
            get { return _instance ?? (_instance = new DatabaseManagement())}
        }
     
        ...
    }
    class Logger
    {
        
        private static Logger _instance;
        public static Logger Inst {
            get { return _instance ?? (_instance = new Logger())}
        }
          
        ...
    }
