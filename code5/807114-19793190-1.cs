    protected void hoursReportGridView_OnRowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField theHiddenField = e.Row.FindControl("HiddenFieldDifferentUsers") as HiddenField;
            // Check that we successfully found hidden field before using it
            if(theHiddenField != null)
            {
                // Do something with hidden field here if you need to
            }
        }
    }
