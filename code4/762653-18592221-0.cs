    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        // Find the div control as htmlgenericcontrol type, if found apply style
        System.Web.UI.HtmlControls.HtmlGenericControl div =  (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("DivContent");
    
        if(div != null)
            div.Style.Add("border-color", "Red");
    
    }
