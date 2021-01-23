    using System.Data.Entity;
    namespace MultipleConnections.Models
    {
        public class BaseContext<TContext> : DbContext where TContext : DbContext
        {
            static BaseContext()
            {
                Database.SetInitializer<TContext>(null);
            }
            public BaseContext(string connectionString = "Name=MSSQLEntities")
                : base(connectionString)
            {}
        }
    }
