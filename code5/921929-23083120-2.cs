        public static class Data   
    {
        static OleDbConnection conn;
        public static OleDbConnection Connection
        {
            get
            {
                if (conn == null)
                    LazyInitializer.EnsureInitialized(ref conn, CreateConnection);
                return conn;
            }
        }
        static OleDbConnection CreateConnection()
        {
            if (strDataFilePath == null)
                throw new Exception("Datafile paths is not set");
            //build connection, using strDataFilePath
            var conn = new OleDbConnection("YourConnectionStringWithDataFilePath"); 
            //other settings
            //open
            conn.Open();
            return conn;
        }
        static string strDataFilePath;
        public static string DataFilePath
        {
            get { return strDataFilePath; }
            set
            {
                if(strDataFilePath==value)return;
                strDataFilePath = value;
                if(conn!=null){
                    conn.Close(); //NB, no checks were added if the connection is being used, but if the value is only set on startup or idle moments, this should be ok for the example.
                    conn.Dispose();
                    conn=null; //conn is reset, and (re)created the next time Connection is called
                }
            }
        }
    }
