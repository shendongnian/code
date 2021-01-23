    int id;
    using (SqlConnection connection = new SqlConnection(AppConstants.ConnectionString))
    {
        string sql = @"INSERT INTO custom_customer (customer_name) 
                                            VALUES (@name); 
                       SELECT SCOPE_IDENTITY();"
        using (SqlCommand command = new SqlCommand(sql))
        {
            command.Parameters.Add(new SqlParameter("name", customer));
            connection.Open();
            id = (int) command.ExecuteScalar();
            connection.Close();
        }
    }
