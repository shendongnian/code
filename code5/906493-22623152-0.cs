    public class MyContext : DbContext
    {
        // Add a constructor that takes a connection string
        public MyContext(string connString)
            : base(connString)
        {         
        }
    }
    // Call this method from a page or controller
    public void ConnectToTheDatabase(string username, string password)
    {
        // create the connection string; I like to user the builder
        System.Data.Common.DbConnectionStringBuilder builder 
            = new System.Data.Common.DbConnectionStringBuilder();
        builder.Add("Server", "tcp:asdfewsdfgwe.database.windows.net,1422");
        builder.Add("Database", "supersonic_db");
        builder.Add("User ID", username);
        builder.Add("Password", password);
        builder.Add("Trusted_Connection", "False");
        builder.Add("Encrypt", "True");
        builder.Add("Connection Timeout", "30");
        var connString = builder.ToString();
        // Set the connection string
        MyContext context = new MyContext(connString);
        // Test with something simple
        context.Database.Connection.Open();
        string version = context.Database.Connection.ServerVersion;
        version = version.ToUpper();
    }
        
