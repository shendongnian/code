    public class UserRepository
    {
        public DbConnection Connection { get; set; }
    
        public User GetUser(string id)
        {
            //...
        }
    }
