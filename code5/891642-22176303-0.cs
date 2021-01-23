    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
      name = reader["name"].ToString().Trim(); // get the name of item
      id  = reader["id"].ToString().Trim(); // get the id of item
    }
    reader.Close();
    conn.Close();
