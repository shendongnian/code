    public IEnumerable<int> GetPages()
    {
        return Enumerable.Range(1, GridView.PageCount);
    }
    protected void PageIndexChanging(object sender, EventArgs e)
    {
        LinkButton pageLink = (LinkButton)sender;
        GridView.PageIndex = Int32.Parse(pageLink.CommandArgument) - 1;
        
        BindDataToGridView();
    }
