            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(queryString, connection))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
