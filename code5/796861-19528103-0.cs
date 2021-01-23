    using(SqlConnection sqlConn = new SqlConnection("connectionString"))
    {
      string query = "INSERT INTO MyTable VALUES (@name, @lastName)";
      SqlCommand cmd = new Sqlcommand(query, sqlConn);
      cmd.Parameters.Add("@name", SqlDbType.Varcharm, 50).Value = textBoxName.Text;
      cmd.Parameters.Add("@lastName", SqlDbType.Varcharm, 50).Value = textBoxLastName.Text;
      cmd.Connection.Open();
      try
      {
        cmd.ExecuteNonQuery();  
      }
      catch{}  
    }
