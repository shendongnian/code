            //Update login query
            string sql = "ALTER LOGIN " + login.ToUpper() + " WITH PASSWORD = '" + password + "' OLD_PASSWORD = '" + oldpassword + "'";
        
            try {
            //Try connection and execute
            using (SqlConnection connection = new SqlConnection(GetConnection()))
            {
                 connection.Open();
            
                 SqlCommand command = new SqlCommand(sql, connection);
                 command.CommandType = System.Data.CommandType.Text;
                 var result = command.ExecuteScalar();
                 connection.Close();
            }
        }
        catch(SQLException)
        {
    //Do something here to tell the user something went wrong
        }
