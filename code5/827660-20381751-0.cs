    using (SqlConnection connection = new SqlConnection(AppConstants.ConnectionString))
    using (SqlCommand command = new SqlCommand("INSERT INTO custom_customer (customer_name) VALUES (@name);SELECT SCOPE_IDENTITY();"))
    {
        command.Parameters.Add(new SqlParameter("name", customer));
        connection.Open();
        int id= (int)Command.ExecuteScalar();
    }
    
