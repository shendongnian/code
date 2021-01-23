    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlConnection SqlConn = new SqlConnection();
        SqlCommand cmd;
        SqlConn.ConnectionString = ConfigurationManager.AppSettings["SqlConn"].ToString();
        SqlConn.Open();
        string query1 = "insert into tbl2(id,name,address) values (@id,@name,@address)";
        cmd = new SqlCommand(query1, SqlConn);
        cmd.Parameters.AddWithValue("@id", txt_id.Text);
        cmd.Parameters.AddWithValue("@name", txt_name.Text);
        cmd.Parameters.AddWithValue("@address", txt_address.Text);
        cmd.ExecuteNonQuery();
        SqlConn.Close();
    }
