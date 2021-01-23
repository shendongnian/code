    public class UserRepository
    {
        public UserRepository(DbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            Connection = connection;
        }
        public DbConnection Connection { get; private set; }
    
        public User GetUser(string id)
        {
            //...
        }
    }
    //Now forced to init the class correctly
    var repos = new UserRepository(dbConnection);
    var user = repos.GetUser("22");
