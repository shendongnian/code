    protected void DD2Bind()
    {
        DD2.DataSource = //fetch data source
        DD2.DataBind();
    }
    protected void DD1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DD2Bind();
    }
