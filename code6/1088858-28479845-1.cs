    using System.Data.Entity;
    
    namespace MultipleConnections.Models
    {
        // Extending Base Context will use default MSSQLEntities connection
        public class MSSQLContext : BaseContext<MSSQLContext>
        {
           ...apply DbSet<> and other loveliness...           
        }
    }
