    public class ModelConfiguration : DbConfiguration 
    { 
        public ModelConfiguration() 
        { 
            this.SetHistoryContext("System.Data.SqlClient", 
                (connection, defaultSchema) => new MyHistoryContext(connection, defaultSchema)); 
        } 
    } 
