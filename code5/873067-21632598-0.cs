    try
    {
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdDb1317466_bk;
            DataTable dt= new DataTable();
            da.Fill(dt);
            DataGridView1.DataSource = dt;
            DataGridView1.DataBind();
    }     
