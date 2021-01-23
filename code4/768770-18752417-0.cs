    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand("select * from users where userName = @pUsername and password = @pPassword", connection))
        {
            command.Parameters.Add(new SqlParameter("pUsername", username));
            command.Parameters.Add(new SqlParameter("pPassword", password));
       
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);  
    
            // The rest of your code here...
         }
    }
