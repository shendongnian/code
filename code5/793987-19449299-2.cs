    ScriptManager sm = ScriptManager.GetCurrent(Page);
    private void GridprodList_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkdis = (CheckBox) e.Row.FindControl("chkdis");
            sm.RegisterAsyncPostBackControl(chkdis);
        }
    }
