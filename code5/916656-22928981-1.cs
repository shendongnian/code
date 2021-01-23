    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if(e.NewPageIndex != 0)
            GridView1.PageSize = 20;
        else
            GridView1.PageSize = 10;
        GridView1.DataBind();
    }
