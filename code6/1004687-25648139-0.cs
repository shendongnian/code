    string query = "insert into results(sid,c_id)values(@id, @cid))";
    MySqlCommand cmd = new MySqlCommand(query, conn);
    cmd.Parameters.Add("@id", MySqlDbType.Int).Value = _stuid;
    cmd.Parameters.Add("@cid", MySqlDbType.Int);
       
    conn.Open();
    for (int cnt = 0; cnt <= lv1.Items.Count - 1; cnt++)
    {
        string subItem = lv1.Items[cnt].SubItems[2].Text;
        if(!string.IsNullOrWhiteSpace(subItem))
        { 
            cmd.Parameters["@cid"].Value = Convert.ToInt32(subItem);
            cmd.ExecuteNonQuery();
        }
     
    }
    conn.Close();
