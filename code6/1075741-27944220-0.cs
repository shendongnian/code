    class DatabaseManagement
    {
        private Logger _logger;
        
        public DatabaseManagement()
        {
            _logger = new Logger(this);
        }
    }
    
    class Logger
    {
        DatabaseManagement _dm;
    
        public Logger(DatabaseManagement dm)
        {
            _dm = dm;
        }
    }
