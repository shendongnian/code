    class Connection
    {
        // the first overload that takes 3 string parameters
        public static OracleConnection GetConnection(string dataSource, string userName, string password)
        {
            .... 
        }
        // The second overload that takes an instance of UserMembers
        public static OracleConnection GetConnection(UserMembers src )
        {
            OracleConnection con = null;
            if(!string.IsNullOrWhiteSpace(sr.srDatabase) && !string.IsNullOrWhiteSpace(sr.srID) && !string.IsNullOrWhiteSpace(sr.srPass))
            {
                    con = new OracleConnection("Data Source=" + sr.srDatabase + ";User Id=" + sr.srID.ToUpper() + ";Password=" + sr.Pass + ";");
            }
            return con;
        }
    }
    }
