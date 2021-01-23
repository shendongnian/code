    protected void Page_Init(Object sender, EventArgs e)
    {
         gridprodlist.DataBound += GridprodList_DataBound;
    }
    private void GridprodList_DataBound(Object sender, EventArgs e)
    {
        ScriptManager sm = ScriptManager.GetCurrent(Page);
        foreach(GridViewRow row in gridprodlist.Rows)
        {
            CheckBox chkdis = (CheckBox) row.FindControl("chkdis");
            sm.RegisterAsyncPostBackControl(chkdis);
        }
    }
