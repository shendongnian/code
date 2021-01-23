    public class DataConnection
    {
        public static SqlConnection Con
        {
            get 
            { 
                return new SqlConnection(ConfigurationManager
                    .ConnectionStrings["conn"].ConnectionString); 
            }
        }
    }
