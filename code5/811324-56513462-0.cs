    public class MyContextConfiguration : DbMigrationsConfiguration<MyContext>
    {
        public MyContextConfiguration()
        {
            CommandTimeout = 900;
        }
    }
