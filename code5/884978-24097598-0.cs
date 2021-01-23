    public class ContextInitializer : DropCreateDatabaseAlways<Context> 
    {
         protected override void Seed(Context context)
         {
             // Get the file and read the text
             var execPath = Assembly.GetExecutingAssembly().Location;
             var createOrderNumPath = Path.Combine(execPath, @"..\SQL\CreateOrderNumber.sql");
             var sql = File.ReadAllText(createOrderNumPath);
     
             // Execute the CREATE TRIGGER on the database.
             // CHANGE emptyparams TO CONTAIN NO ELEMENTS
             var emptyparams = new SqlParameter[] { };
             context.Database.ExecuteSqlCommand(sql, emptyparams);
     
             base.Seed(context);
         }
    }
