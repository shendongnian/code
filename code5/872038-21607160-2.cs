    public class Database
    {
        public static MySqlConnection Connect()
        {
             static MySqlConnection connection;
             String cs = null;            
               cs = @"datasource=localhost;
               port=3306;
               userid=XXXX;
               password=XXXX;
               database=XXXX";
            try
            {
                connection = new MySqlConnection(cs);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Log error...;
            }
            return connection;
        }
    }
