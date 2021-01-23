            string connectionString = "";
            string html = "<div id=\'loremIpsum\'><div/>";
            using (SqlCommand command = new SqlConnection(connectionString).CreateCommand())
            {
                command.CommandText = "insert into YourTable (YourColumn) values(@yourParameter)";
                command.Parameters.Add(new SqlParameter("yourParameter", html));
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    command.Connection.Close();
                }
            }
