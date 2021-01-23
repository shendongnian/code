    public class CommonDbContext : DbContext
    {
        public CommonDbContext(string connectionString)
            :base(connectionString)
        {
            
        }
        public IDbSet<Table1> Tables1 { get; set; }
    }
