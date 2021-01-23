    using (SqlConnection connection = new SqlConnection("connectionString"))
    {
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "select columns from accounts";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //fetch additional data for each record.
                    using (SqlCommand innerCommand = connection.CreateCommand())
                    {
                        innerCommand.CommandText = "select * from sales where account_id = @account_id";
                        using (SqlDataReader innerReader = innerCommand.ExecuteReader())
                        {
                            while (innerReader.Read())
                            {
                                //read sales data    
                            }
                        }
                    }
                }
            }
        }
    }
