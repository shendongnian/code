    public static class Data    
    {
        public static readonly Lazy<OleDbConnection> Connection = new Lazy<OleDbConnection>(CreateConnection); //(using System.Threading)
        static OleDbConnection CreateConnection()
        {
            var conn = new OleDbConnection("YourConnectionString");
            //etc
            conn.Open();
            return conn;
        }
    }
