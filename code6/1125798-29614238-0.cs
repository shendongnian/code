    private static void OpenSqlConnection(string connectionString)
    {
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        //Do some work
    }
    }
