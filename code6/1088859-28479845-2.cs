    using System.Data.Entity;
    
    namespace MultipleConnections.Models
    {
        // Extending Base Context
        public class OracleContext : BaseContext<OracleContext>
        {
            // Declare Oracle connection in Constructor to override default
            // MSSQL connection
            public OracleContext()
                : base("Name=OracleEntities")
            { }
           ...apply DbSet<> and other loveliness...           
        }
    }
