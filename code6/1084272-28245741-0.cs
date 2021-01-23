    private readonly string dbConnection;
    private const string query = "SELECT COUNT(*) AS Rows FROM [Table] WHERE Id = @Id";
    
    int? rows;
    using(SqlConnection connection = new SqlConnection(dbConnection))
         using(SqlCommand command = new SqlCommand(query, connection))
         {
              connection.Open();
              command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
              // command.Parameters.AddWithValue("@Id", id); // Another approach.
              using(SqlDataReader reader = command.ExecuteReader())
                   if(reader.Read())
                        rows = reader["Rows"] as int?;
         }
