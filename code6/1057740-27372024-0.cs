    using (MySqlConnection conn = new MySqlConnection(myConnection))
    {
        conn.Open();
        MySqlCommand cmd1 = new MySqlCommand(query2, conn);
        MySqlDataReader reader = cmd1.ExecuteReader();
    
        while (reader.Read())
        {
            List li = new List();
            li.linkLabel1.Text = reader["TitleAnime"].ToString();
            flowLayoutPanel1.Controls.Add(li);
        }
        conn.Close();
    }
