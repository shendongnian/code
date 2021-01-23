    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            //Set our new history context to be the one that gets used
            this.SetHistoryContext("System.Data.SqlClient",
                (connection, defaultSchema) => new MyHistoryContext(connection, defaultSchema)); 
        }
    }
