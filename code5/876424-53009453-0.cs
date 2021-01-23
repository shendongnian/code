        SqlConnectionStringBuilder sqlb = new  SqlConnectionStringBuilder(getConnectionString(DATABASENAME);
        
        using (SqlConnection connection = new SqlConnection(sqlb.ConnectionString))
        ...
        )
        // works for EF Core, should also work for EF6 (haven't tried this) 
        private static string getConnectionString(string databaseName)
        {
            return "Data Source=SQLSERVERNAME;Initial Catalog="+databaseName+";Integrated Security=True";
        }
       
