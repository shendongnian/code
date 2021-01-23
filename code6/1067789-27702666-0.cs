    public class DatabaseDataContext : DataContext
    {
        private static DatabaseDataContext instance;
        private SqlConnection sqlConnection;        
        private SqlTransaction sqlTransaction;
        
        //...
        public static DatabaseDataContext Instance
        {
            get
            {
                return instance ?? (instance = new DatabaseDataContext(connectionString));
            }
            set
            {
                instance = value;
            }
        }
    }
