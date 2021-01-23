    public void BindData()
    {
        SqlConnection con = new SqlConnection(@"server=RSTT2; database = Project ;  User Id=sa; Password=PeaTeaCee5#");
        con.Open();
        string strCmd = "select supportID from Support";
        SqlCommand cmd = new SqlCommand(strCmd, con);
        SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        con.Close();
        cbSupportID.DisplayMember = "supportID";
        cbSupportID.ValueMember = "supportID";       
        cbSupportID.DataSource = ds;
       
        cbSupportID.Enabled = true;
    }
