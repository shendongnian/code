    for (int i = 0; i < number; i++)
    {
        //Initialize this however you need to
        using (SqlConnection connection = new SqlConnection())
        {
            connection.Open();
            using (SqlCommand command = 
                new SqlCommand("InsertMsg", connection, connection.BeginTransaction())
                {
                    CommandType = CommandType.StoredProcedure
                })
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.Add("@ID", SqlDbType.VarChar).Value = IDs[i];
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = names[i];
                    command.Parameters.Add("@age", SqlDbType.DateTime).Value = age;
                    command.ExecuteNonQuery();
                    data[i] = IDs[i];
                    command.Transaction.Commit();
                }
                catch (SqlException ex)
                {
                    command.Transaction.Rollback();
                    data[0] = "Error";
                }
            }
        }
    }
    return data;
