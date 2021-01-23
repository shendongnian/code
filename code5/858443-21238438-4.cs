    protected void gvResults_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dtSortTable = gvResults.DataSource as DataTable;
            if (dtSortTable != null)
            {
                // get sort direction (ASC or DESC)
                string sortDirection = GetSortDirection(e.SortExpression);
                
                DataView dvSortedView = new DataView(dtSortTable);
                dvSortedView.Sort = e.SortExpression + " " + sortDirection;
                gvResults.DataSource = dvSortedView;
                gvResults.DataBind();
                // save current sort expression and sort direction to ViewState
                this.SortExpression = e.SortExpression;
                this.SortDirection = sortDirection;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling.NETException(ex, constPageID, constIsSiteSpecific);
        }
    }
