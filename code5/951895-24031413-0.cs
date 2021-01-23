    public class MyContext : DbContext
    {
        public MyContext()
             : base("Name=NameOfConnectionString")
        {
        }
    }
