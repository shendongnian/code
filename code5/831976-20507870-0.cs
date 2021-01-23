    public static class ConnectionStrings
    {
        #if DEBUG
        public static string DBName
        {
            get
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = @"C:\devDB.mdb",
                    Provider = "Microsoft.Jet.Oledb.4.0"
                };
                return builder.ToString();
            }
        }
        #else
        public static string DBName
        {
            get
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = @"C:\prodDB.mdb",
                    Provider = "Microsoft.Jet.Oledb.4.0"
                };
                return builder.ToString();
            }
        }
        #endif
    }
