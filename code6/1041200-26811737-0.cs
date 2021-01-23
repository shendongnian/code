    public class DB
    {
        public enum Provider { 
            SqlServer, MySql, Oracle//, ...
        }
        public DB()
        {
            this.CurrentProvider = Properties.Settings.Default.Provider; // presuming that you have this setting
        }
        public Provider CurrentProvider { get; set; }
        public IDbConnection NewConnection()
        {
            switch (this.CurrentProvider) { 
                case Provider.SqlServer:
                    return new SqlConnection(Properties.Settings.Default.ConnectionString);
                case Provider.MySql:
                    return new MySql.Data.MySqlClient.MySqlConnection(Properties.Settings.Default.ConnectionString);
                    // ...
                default: throw new NotSupportedException(CurrentProvider.ToString());
            }
        }
        //  and other methods ....
    }
