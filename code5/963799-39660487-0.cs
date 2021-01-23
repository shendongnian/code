    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    { 
        SetSortDirection(SortDireaction);
        if (dataTable != null)
        {
           dataTable.DefaultView.Sort = e.SortExpression + " " +_sortDirection;
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            SortDireaction = _sortDirection;
        }
    } 
    protected void SetSortDirection(string sortDirection)
    {
        if (sortDirection == "ASC")
        {
            _sortDirection = "DESC";
        }
        else
        {
            _sortDirection = "ASC";
        }
    } 
