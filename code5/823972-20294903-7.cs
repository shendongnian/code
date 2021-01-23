    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(string dbName) : base(GetConnectionString(dbName))
        {
        }
        public static string GetConnectionString(string dbName)
        {
            // Server=localhost;Database={0};Uid=username;Pwd=password
            var connString = 
                ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString.ToString();
            return String.Format(connString, dbName);
        }
    }
