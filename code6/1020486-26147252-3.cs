    int professorId;
    private static void ReadOrderData(string connectionString)
    {
        string queryString = "select ID_ST from [dbo].[PROFESSOR];";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(queryString, connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Call Read before accessing data. 
                if (reader.HasRows())
                { 
                    reader.Read(); 
                    professorId = reader.GetInt32(0);
    
                    // Call Close when done reading.
                    reader.Close();
                }
            }
        }
    }
