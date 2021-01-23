    public static class BuildConnection()
    {    
        public static GetConnectionString(var userName, var Password)
        {
              OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
              builder.Driver = "Microsoft Access Driver (*.mdb)";        
              builder.Add("Dbq", @"C:\Test\Test.mdb");
              builder.Add("User Id", userName);
              builder.Add("Password", Password);
              return builder.ConnectionString; // Here is your connection String 
        }
    }
