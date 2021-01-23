    public void foo()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "insert ...";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    ...
                }
            }
        }
