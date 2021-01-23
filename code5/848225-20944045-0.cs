    protected void grdPBook_RowCreated(object sender, GridViewRowEventArgs e)
    {
    // your code
    if (ddlSummary.SelectedValue == "0")
    {
    //your code
    grdPBook.DataSource = dt;
    //here dt is your Data Table object containing all rows.
    }
    grdPBook.DataBind();
    }
