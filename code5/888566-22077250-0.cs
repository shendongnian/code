    public class MyDataContext : DbContext
    {
        public MyDataContext(String nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
