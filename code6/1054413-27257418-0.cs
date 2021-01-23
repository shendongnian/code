    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("ConnectionStringName")
        {
            Database.SetInitializer<ApplicationContext>(null);
        }
        // DbSets here
    } 
