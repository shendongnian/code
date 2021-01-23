    protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           RangeValidator rv = (RangeValidator)e.Row.FindControl("MarksValidation");
           rv.MaximumValue = 50*ValueFromDb;
       }
    }
