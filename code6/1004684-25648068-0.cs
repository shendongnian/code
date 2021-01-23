    for (int cnt = 0; cnt <= lv1.Items.Count - 1; cnt++)
    {
         if(lv1.Items[cnt].SubItems[2].Text=="")
             continue;
        string query = "insert into results(sid,c_id)values('" + _studid + "','" + lv1.Items[cnt].SubItems[2].Text + "')";
    
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
