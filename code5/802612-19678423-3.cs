    protected void btnSearch_Click(object sender, EventArgs e)
    {
        .......
        .......
        GVPolice.DataSource = ds.Copy();
        GVPolice.DataBind();
        Session["gridview"] = ds.Tables[0];
        conn.Close()
    }
