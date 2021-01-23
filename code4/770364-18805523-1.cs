    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public IEnumerable SearchResults_GetData(int startRowIndex, int maximumRows, out int totalRowCount, string sortByExpression)
    {
        int pageIndex = (int)(startRowIndex / maximumRows);
        return Membership.GetAllUsers(pageIndex, maximumRows, out totalRowCount);
    }
    protected void SearchResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchResults.PageIndex = e.NewPageIndex;
        SearchResults.DataBind();
    }
