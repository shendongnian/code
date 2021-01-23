    protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           RangeValidator rv = (RangeValidator)e.Row.FindControl("MarksValidation");
           rv.MaximumValue = 50*Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ColumnFromDatabase"));;
       }
    }
