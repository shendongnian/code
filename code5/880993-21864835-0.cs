    public static void Main()
    {
        string connectionString = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;database=InsertDatabaseNameHere; connection timeout=30";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("select ColumnName from TableName", connection);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetValue(0));
        }
        connection.Close();
    }
