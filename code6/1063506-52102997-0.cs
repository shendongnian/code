    public class ConnectionManager
    {
        public static int BusyTimeout { get; set; }
        
        public static object instanceLock;
        
        static ConnectionManager()
        {
            instanceLock = new object();
            BusyTimeout = Convert.ToInt32(TimeSpan.FromMinutes(2).TotalMilliseconds);
        }
        public static SQLiteConnection CreateConnection(string connectionString)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            using (SQLiteCommand command = connection.CreateCommand())
            {
                command.CommandText = string.Format("PRAGMA busy_timeout={0}", BusyTimeout);
                command.ExecuteNonQuery();
            }
            return connection;
        }
    }
