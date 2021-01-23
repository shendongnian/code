    public class HangfireContext : DbContext
    {
        public HangfireContext() : base("name=HangfireContext")
        {
            Database.SetInitializer<HangfireContext>(null);
            Database.CreateIfNotExists();
        }
    }
