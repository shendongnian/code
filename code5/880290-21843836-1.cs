       string sql = "SELECT name, population FROM city WHERE population > @population"
       using (var conn = new MySqlConnection(/*Connection String*/))
       { 
            conn.Open();
            using (var cmd  = new MySqlCommand(sql, conn))
            {
                 cmd.Parameters.AddWithValue("@population", 4000000);
                 using (var reader = cmd.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                          Console.WriteLine("City: {0} Population: {1}", 
                                           reader["name"], reader["population"]);
                     }
                 }
            }
        }
