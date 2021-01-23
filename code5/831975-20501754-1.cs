    public class Utils
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=YourDB; Integrated Security=true";
        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
    }
