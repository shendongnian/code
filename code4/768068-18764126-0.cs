    public class DataStore : DbContext, IDataStore
    {
        public int UserID { get; private set; }
        // This is the constructor that will be called by the factory class 
        // if it is initialised without a connection string parameter
        public DataStore(int userId)
        {
            UserID = userId;
        }
        public DataStore(int userId, string connectionString) : base(connectionString)
        {
            UserID = userId;
        }
        public virtual IDbSet<User> Users { get; set; }
        // Rest of code here
    }
