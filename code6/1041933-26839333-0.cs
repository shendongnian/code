    using (SqlConnection connection = new SqlConnection(connectionString)) 
    {    
         connection.Open();
         SqlCommand command = new SqlCommand("spTest", connection);
         command.CommandType = CommandType.StoredProcedure;
         command.Parameters.Add(new SqlParameter("@employeeid", employeeID));
         command.CommandTimeout = 5;
    
         command.ExecuteNonQuery();
    }
