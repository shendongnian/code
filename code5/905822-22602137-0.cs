    protected void btnsearch_Click(object sender, EventArgs e)
    {
        string q = "Select * from facultyreg where fname ='"+txtsearch.Text.ToString() + "'";
        sda = new SqlDataAdapter(q, con);
        ds = new DataSet();
        sda.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
       /* cmd = new SqlCommand(q,con);
        if (sdr.HasRows && sdr != null)
        {
            sdr.Read();
        }*/
    }
