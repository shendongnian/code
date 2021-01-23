    String SQLQuery = "SELECT Top 1 UserId, role  FROM aspnet_Users where Username=@uname AND Password = @pwd";
        using(SqlConnection sqlConnection = new SqlConnection(strConnection))
        using(SqlCommand command = new SqlCommand(SQLQuery, sqlConnection))
        {
            sqlConnection.Open();
            command.Parameters.AddWithValue("@uname", Username);
            command.Parameters.AddWithValue("@pwd", Password);
           
             SqlDataReader Reader = null;
             if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
                        sqlConnection.Open();
                Reader = command.ExecuteReader();
               if (Reader.Read())
              {
                int UserId = Convert.ToInt32(Reader["UserId"]);
                string Role = Convert.ToString(Reader["role"]);
    
              }
           
       }
