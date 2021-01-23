    protected void Application_Start()
    {
        Database.SetInitializer(new MyDatabaseInitializer());
    }
    public class MyDatabaseInitializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
         protected override void Seed(DbContext context)
         {
            context.Database
                 .ExecuteSqlCommand(string.Format("ALTER TABLE {0} ADD DEFAULT ({1}) FOR [{2}]", "Users", "getdate()", "CreatedDate"));
         }
    }
