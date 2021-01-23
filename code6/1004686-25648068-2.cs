    conn.Open();
    for (int cnt = 0; cnt <= lv1.Items.Count - 1; cnt++)
    {
         if(lv1.Items[cnt].SubItems[2].Text=="")
             continue;
    MySqlCommand m = new MySqlCommand(readCommand);
    m.Parameters.Add(new MySqlParameter("@id", _studid));
    m.Parameters.Add(new MySqlParameter("@val", lv1.Items[cnt].SubItems[2].Text));
        string query = "insert into results(sid,c_id)values(@id, @val)";
    
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.ExecuteNonQuery();
    }
    conn.Close();
