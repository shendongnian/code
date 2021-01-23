    private void button1_Click(object sender, EventArgs e)
    {
        listView1.View = View.Details;
        SqlConnection con = new SqlConnection("connectionstring");
        SqlDataAdapter ada = new SqlDataAdapter("select * from MasterLocation", con);
        DataTable dt = new DataTable();
        ada.Fill(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            ListViewItem listitem = new ListViewItem(dr["pk_Location_ID"].ToString());
            listitem.SubItems.Add(dr["var_Location_Name"].ToString());
            listitem.SubItems.Add(dr["fk_int_District_ID"].ToString());
            listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
           listView1.Items.Add(listitem);
        } 
