    public class AppDb : DbContext
    {
        public AppDb()
            : base("MainDb")
        {
        }
    }
    public class AnotherDb : DbContext
    {
        public AnotherDb()
            : base("AnotherDb")
        {
        }
    }
