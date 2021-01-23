    using (SqlConnection connection = new SqlConnection(connectionString))
    {
      SqlCommand command = new SqlCommand("insert into tblmain values(@name")", connection);
      command.Parameters.Add("@name", SqlDbType.String);
      command.Parameters["@name"].Value = customerID;
      connection.Open();
      Int32 rowsAffected = command.ExecuteNonQuery();
      Console.WriteLine("RowsAffected: {0}", rowsAffected);
    }
