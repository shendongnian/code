    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        DataView dView = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        if (dView.Count == 1)
            Response.Redirect("~/Default.aspx");
        else
            lblError.Text="Incorrect username or password!";
    }
