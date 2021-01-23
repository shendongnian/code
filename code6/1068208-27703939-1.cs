    public class Globals
    {
        // Keep global just the connection string 
        // (albeit you could simply pass it every time)
        public static string ConnString {get;set;};
        // Change the OpenConnection method to return the SqlConnection created 
        public static SqlConnection OpenConnection()
        {
            SqlConnection cnn = new SqlConnection(ConnString);
            cnn.Open();              
            return cnn;
        }
    }
    
    .....
    public class Service1 : System.Web.Services.WebService
    {
        private static bool Initialized = false;
        public Service1()
        {
            // This method called each function call
            if (!Initialized )
            {
                // Don't hard code the connectionstring details, read it from CONFIG
                // See ConfigurationManager class....
                string connectionString = ReadConnectionStringFromYourConfigFile()
                Globals.ConnString = connectionString;
                Initialized = true;
            }
        }
    
        // An usage example of your Globals
        public int GetDatabaseValue()
        {
             using(SqlConnection cn = Globals.OpenConnection())
             {
                .....
             } // Here the connection will be closed and disposed also in case of exceptions...
        }
    }
