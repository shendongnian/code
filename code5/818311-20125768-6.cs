    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        //Assuming you have a connection string strConnect
        using (SqlConnection con = new SqlConnection(strConnect))
        {
            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customer", con))
            {
                da.Fill(dt);
            }
        }
        dg.ShowFooter = true;
        dg.DataSource = dt;
        dg.DataBind();
    }
