    public void DynamicConnectionExample(string connectionString)
    {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        bool shouldImplicitlyDisposeOfSqlConnection = true;
        using (var ctx = new MyModelContext(sqlConnection, shouldImplicitlyDisposeOfSqlConnection ))
        {
            // do stuff...
        }
     }
