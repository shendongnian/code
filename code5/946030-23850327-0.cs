    int x=0;
    using (
    SqlConnection connection = new SqlConnection(strCon))
    {
        SqlCommand command = new SqlCommand(sql_string, connection);
        connection.Open();
        DataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                x = reader.GetInt32(0);
            }
        } 
  
        reader.Close();
    }
