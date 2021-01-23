    // Create global
    private string _area = "";
    // Then in your binding
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
