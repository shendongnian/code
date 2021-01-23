    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        // Only work with data rows, ignore header and footer rows
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            if(DataBinder.Eval(e.Row.DataItem, "Difference") == null)
            {
                CheckBox the101Checkbox = e.Row.FindControl("cb101") as CheckBox;
                // Verify the check box was found before we try to use it
                if(the101Checkbox != null) 
                {
                    the101Checkbox.Enabled = false;
                }
            }
            else
            {
                if(DataBinder.Eval(e.Row.DataItem, "Difference") == "1")
                {
                    CheckBox the101Checkbox = e.Row.FindControl("cb101") as CheckBox;
                    // Verify the check box was found before we try to use it
                    if(the101Checkbox != null) 
                    {
                        the101Checkbox.Checked = true;
                    }
                }
            }
        }
    }
