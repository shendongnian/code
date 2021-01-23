    public class MyContext : DbContext
    {
        static MyContext ()
        {
            Database.SetInitializer<MyContext>(null);
        }
        //...
    }
