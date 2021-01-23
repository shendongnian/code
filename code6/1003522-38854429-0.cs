    public class DBConfig
    {
        public static readonly DBInitializer Initalizer = new DBInitializer();
        public static void InitalizeDB()
        {
            System.Data.Entity.Database.SetInitializer<DMPDataContext>(Initalizer);
        }
    }
    protected void Application_Start()
        {
            //common application startups
            DBConfig.InitalizeDB();
			//...			
        }
