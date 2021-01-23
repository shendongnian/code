    protected void Button1_Click(object sender, EventArgs e)
    {
        string conStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\website\w2\App_Data\Database.mdf;Integrated Security=True;User Instance=True";
        SqlConnection con1 = new SqlConnection(conStr);
        con1.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT id,staff FROM staff_details  ", con1);
        adapter.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con1.Close();
    }
