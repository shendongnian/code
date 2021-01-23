    public class MyContext : DbContext
    {
        static MyContext()
        {
            
        }
        public MyContext()
            : base("Name=DefaultConnection")
        {
            
        }
    }
