    using(SqlConnection connection = new SqlConnection(
            connectionString)) {
        using(SqlCommand command = new SqlCommand()) {
                SqlDataReader reader = null;
            try {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM <TABLE> WHERE <FIELD> IN (@PARAM)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter(@"@PARAM",
                        String.Join(",", <array>)));
                connection.Open();
                reader = command.ExecuteReader();
                if(reader.HasRows) {
                    // logic
                }
            } catch(SqlException) {
                throw;
            }
        }
    }
