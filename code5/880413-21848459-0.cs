    private void button1_Click(object sender, EventArgs e)
    {           
       SqlConnection con = new SqlConnection(@"SQLCONNECTIONSTRING");
       con.Open();
       SqlCommand cmd = new SqlCommand("Select * from tbl_members", con);
       SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       //SqlDataReader reader = cmd.ExecuteReader();
       DataTable dt = new DataTable();
       dt.Columns.Add("FullName", typeof(string));
       DataSet ds = new DataSet();
       adapter.Fill(ds);
       dt=ds.Tables[0];
       checkedListBox1.DisplayMember = "FullName";
       checkedListBox1.ValueMember = "FullName";
       checkedListBox1.DataSource = ds.Tables[0];
       checkedListBox1.Enabled = true;
       checkedListBox1.Refresh();
       con.Close();
   }
