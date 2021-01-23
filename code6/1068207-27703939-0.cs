    public class Globals
    {
        public static string ConnString {get;set;};
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
             }
        }
    }
