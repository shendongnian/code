    using(SqlConnection con = new SqlConnection(connString))
    using(SqlCommand cmd = new SqlCommand())
    {
         cmd.Connection = con;
         cmd.CommandText = "SELECT Goal from Planning WHERE Id = @Id";
         cmd.Parameters.AddWithValue("@Id", YourIdValue);
         try
         {
             conn.Open();
             int goal = (int)cmd.ExecuteScalar();
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
         }
    }
