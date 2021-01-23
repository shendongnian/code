       string queryString="SELECT * FROM info where id=@id";
       using (MySqlConnection connection = new MySqlConnection(connectionString))
       using (MySqlCommand command = new MySqlCommand(queryString, connection))
       {
            connection.Open();
            command.Parameters.AddWithValue(@id, textBox1.Text);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // do something ...
                }
            }
        }
