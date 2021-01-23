    protected void gvEntity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           //CheckBox cbAttachClrReq = (CheckBox) e.Row.FindControl("chkAdd");
           //check the value here and set enable property
           e.Row.Enabled = false;
          
        }
    
    }
