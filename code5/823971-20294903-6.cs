    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("mysqlCon")
        {
        }
    }
