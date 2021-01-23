    protected string SortColummn 
    {
        get { return ViewState["SortColumn"].ToString(); }
        set { ViewState["SortColumn"] = value; }
    }
    protected string SortDirection 
    {
        get { return ViewState["SortDirection"].ToString(); }
        set { ViewState["SortDirection"] = value; }
    }
