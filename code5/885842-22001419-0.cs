    protected void SehenList_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        var pnl = SehenList.InsertItem.FindControl("UPCityFKInsert") as UpdatePanel;
    
        if (pnl != null)
        {
            var ddlDistrictInsert = pnl.FindControl("DistrictDropDownListInsert") as DropDownList;
            if (ddlDistrictInsert != null) ddlDistrictInsert.Enabled = true;
        }
    }
