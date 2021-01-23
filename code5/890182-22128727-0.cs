     public static int update(DataTable dt, string id, string table)
     {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
           MySqlDataAdapter adapter = new MySqlDataAdapter();
           adapter.UpdateCommand = new MySqlCommand("UPDATE " + table + " SET username=@username,password=@password WHERE id=" + id, conn);
           adapter.UpdateCommand.Parameters.Add("@username",MySqlDbType.VarChar,30).Value = usernameValue;
           adapter.UpdateCommand.Parameters.Add("@password", MySqlDbType.VarChar, 30).Value = passwordValue;
           conn.Open(); 
           adapter.Fill(dt);
           adapter.Update(dt);
        }
     }
