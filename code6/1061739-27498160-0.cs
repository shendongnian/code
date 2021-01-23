    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        Label txtNumber = (Label)e.Row.FindControl("txtNumber");
        txtNumber.ForeColor = System.Drawing.Color.Red;
    }
