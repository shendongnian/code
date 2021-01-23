    using (connection)
        {
            SqlCommand command = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = sqlQuery;
            connection.Open();
    
            SqlDataReader reader = command.ExecuteReader();
    
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                     /// you can get values
                }
            }        
            reader.Close();
        }
