    using (MySqlConnection conn = new MySqlConnection(constring))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.Connection = conn;
            conn.Open();
    
            cmd.CommandText = "select * from edata where id = 1;";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
    
            conn.Close();
            DateTime dateStart = Convert.ToDateTime(dt.Rows[0]["StartSub"]);
            DateTime dateEnd = Convert.ToDateTime(dt.Rows[0]["EndSub"]);
    
            if (DateTime.Now >= dateStart && DateTime.Now <= dateEnd)
            {
                TimeSpan ts = dateEnd - DateTime.Now;
                label1.Text = "Active";
                label2.Text = ts.TotalDays + " day(s) left";
            }
            else
            {
                label1.Text = "Expired";
                label2.Text = "0 day left";
            }
        }
    }
