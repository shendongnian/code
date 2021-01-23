     protected void EventRequirementGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && && e.Row.RowState == DataControlRowState.Edit)
            {
               if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {            
                   DropDownList ddllist = (DropDownList)e.Row.FindControl("modeldropdownlist");
                   ddllist.SelectedValue = DataBinder.Eval(e.Row.DataItem, "exammode").ToString();               
                }
             }
        }
