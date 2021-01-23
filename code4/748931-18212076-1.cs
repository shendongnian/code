            SqlCommand command =
                new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                //read data here
            }
           
            reader.Close();
        }
