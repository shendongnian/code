    public class DataLayer()
    {
        string ConnectionString {get; set;}
        public DataLayer(string connectionString)
        {
           ConnectionString = connectionString;  
        }
        public void UpdateUser(SystemUser user)
        {
            //do update command here
        }
    }
