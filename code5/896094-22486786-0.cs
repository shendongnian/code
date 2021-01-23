    public class MyDbContext : DbContext
        public ScipCcEntities(string schema)
            : base("Name=" + schema)
        {
        }
