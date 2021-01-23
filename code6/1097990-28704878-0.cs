    public class Service : IService
    {       
        private static SQLConnection con;
        public Company GetCompany(int key)
        {
            // Get existing database connection
            // SELECT * from companies where c_key=key
            // Return Company instance
        }
    }
