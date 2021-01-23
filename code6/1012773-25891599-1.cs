    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Month"]))
            {
                Label Month = (Label)e.Row.FindControl("Month");
                Month.Text = string.Format(new CultureInfo("de-DE"),
                                                  "{0:MMMM yyyy}", 
                                           DataBinder.Eval(e.Row.DataItem, "Month"));
            }
        }
    }
