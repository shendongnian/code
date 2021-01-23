    public class MyContext : DbContext
    {
        static MyContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
    }
