    public class DatabaseTestInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            SeederHelper.Seed(context);
        }
    }
