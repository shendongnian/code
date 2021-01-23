    using(OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\DB.accdb"))
    {
      cmd = new OleDbCommand(@"INSERT INTO Nodes ([J_ID],[Node ID],[Node MAC],[Line Quality],[Status])
                             values(?, ?, ?, ?, ?", conn);
      cmd.Parameters.AddWithValue("@id", id);
      cmd.Parameters.AddWithValue("@nodeid", 0);
      cmd.Parameters.AddWithValue("@nodemac", BitConverter.ToString(mac));
      cmd.Parameters.AddWithValue("@line", 0);
      cmd.Parameters.AddWithValue("@status", "Join");
      conn.Open();
      cmd.ExecuteNonQuery();
      conn.Close();
    }
