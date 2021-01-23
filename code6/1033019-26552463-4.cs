    string query = @"SELECT * FROM [Table] WHERE ([Column] = @Id);";
    using(SqlConnection connection = new SqlConnection(...))
         using(SqlCommand command = new SqlCommand(query, connection))
         {
              command.Parameters.AddWithValue("@Id", parameter); // OR
              command.Parameters.Add("@Id", SqlDbType.Int).Value = parameter;
         }
