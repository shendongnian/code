    public class MyDbContext : DbContext
    {
        static MyDbContext()
        {
            // I don't want to initialize my database from code, I already have a database.
            Database.SetInitializer<MyDbContext>(null);
        }
        //
        //
        // you dbsets goes here
    }
