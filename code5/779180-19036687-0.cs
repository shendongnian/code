    protected void search_Click(object sender, EventArgs e)
    {
        PopGrid();
    }
    protected void searchresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        searchresult.PageIndex = e.NewPageIndex;
        PopGrid();
    }
    protected void PopGrid()
    {
        List<someclass> totalResult = new List<someclass>();
        ..... //some code to generate the datasource
    
        searchresult.DataSource = totalResult;
        searchresult.AllowPaging = true;
        searchresult.DataBind();
    }
