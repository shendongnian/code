    string queryString ="(SELECT * FROM tblEmployee WHERE Username = 'Venz')";
    using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(queryString, connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                        }
                    }
                }
