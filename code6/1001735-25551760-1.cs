    // Create global *NOT* in your binding method
    private string _area = "";
    // Then in your binding method change it to read the row data assuming this is
    // where you want to get the area from.
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        DataRowView drv = e.Row.DataItem as DataRowView;
        area = drv["area"].ToString();
    }
    else if (e.Row.RowType == DataControlRowType.Footer)
    {
        // your other code here...
        // then replace the assignment
        area.SelectedValue = _area;
    } 
