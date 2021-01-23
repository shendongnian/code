    private int GetColumnIndex(GridView grv, string SortExpression)
    {
        int i = 0;
        foreach (DataControlField c in grv.Columns)
        {
            if (c.SortExpression == SortExpression)
                break;
            i++;
        }
        return i;
    }
    
    protected void grvSampleOrders_Sorting(object sender, GridViewSortEventArgs e)
    {
        Utility_Web.PersistSortDirection(Session, (((Control)sender)).ID, e.SortExpression, e.SortDirection);
    
        grvSampleOrders.DataSource = Utility_Web.GetSortedDataView(Session, dsSampleOrders, (((Control)sender)).ID); // replace original SQL data source with its sorted copy
        grvSampleOrders.DataBind();
        grvSampleOrders.HeaderRow.Cells[GetColumnIndex(grvSampleOrders, e.SortExpression)].CssClass = Session["grvSampleOrders_sort"].ToString().Equals("ASC") ? "sortasc" : "sortdesc";
    }
