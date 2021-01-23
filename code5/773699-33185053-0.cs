    public class WRContext : DbContext
    {
        public WRContext()
            : base("localWR")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }
        public DbSet<Emp> Emps { get; set; }
        //....
    }
