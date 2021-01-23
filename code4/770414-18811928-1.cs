     protected void SortRecords(object sender, GridViewSortEventArgs e)
    {
         string sortExpression = e.SortExpression;
         string direction = string.Empty;
            if (SortDirection == SortDirection.Ascending)
                 {
                      SortDirection = SortDirection.Descending;
                      direction = " DESC";
                 }
            else
                {
                     SortDirection = SortDirection.Ascending;
                     direction = " ASC";
                }
        DataTable table = this.LoadGrid(); // or this.GetDataTable(), to get only the DataTable
       // Now apply Sorting to your source of Data
        table.DefaultView.Sort = sortExpression + direction;
       // Bind the GridView
        gvLogNotice.DataSource = table;
        gvLogNotice.DataBind();
    }
