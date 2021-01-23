    MySqlCommand cmd = new MySqlCommand("select * from table where user = '" + user.Text + "'", con);
    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
    DataSet ds1 = new DataSet();
    da.Fill(ds1);
    int i = ds1.Tables[0].Rows.Count;
    if (i > 0) {
        // Exist
    }
    else {
        // Add 
    }
