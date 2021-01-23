    MySqlCommand CmdB = new MySqlCommand("", ConnectionB);
    CmdB.CommandText = "INSERT INTO ServerB.TableB (col1, col2) VALUES (@val1, @val2)";
    CmdB.Parameters.AddWithValue("@val1", 0); // Default values
    CmdB.Parameters.AddWithValue("@val2", 0);
    
    using (MySqlCommand cmd = new MySqlCommand("", ConnectionA))
    {
        cmd.CommandText = "SELECT col2, col3 FROM ServerA.TableA";
    
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                CmdB.Parameters["@val1"].Value = reader.GetInt32(0));
                CmdB.Parameters["@val2"].Value = reader.GetInt32(1));
                CmdB.ExecuteNonQuery();
            }
    
        }
    }
