    SqlConnection connection = new SqlConnection(connectionString)
    SqlCommand command = new SqlCommand(query, connection);
    
    command.Parameters.Add("@ID", SqlDbType.NChar);
    command.Parameters["@ID"].Value = "abc";
    
    etc
    
    command.ExecuteNonQuery();
