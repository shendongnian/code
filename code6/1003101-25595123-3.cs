    static void UpdateOrInsertBuses(String rego, String oprt, String service)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "updateData";
                command.Parameters.Add(new SqlParameter("@inrego", rego));
                command.Parameters.Add(new SqlParameter("@inOprt", oprt));
                command.Parameters.Add(new SqlParameter("@inService", service));
                connection.Open();
                try
                {
                    int update = command.ExecuteNonQuery();
                    Console.WriteLine(update);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
    
    // ...
    // Add data
    UpdateOrInsertBuses("11", "12", "13");
    UpdateOrInsertBuses("21", "22", "23");
    // Update added
    UpdateOrInsertBuses("21", "22", "Changed for sure");
