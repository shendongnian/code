    protected void EventRequirementGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && && e.Row.RowState == DataControlRowState.Edit)
        {                     
               DropDownList ddllist = (DropDownList)e.Row.FindControl("modeldropdownlist");
               ddllist.SelectedValue = DataBinder.Eval(e.Row.DataItem, "exammode").ToString();               
        }
    }
