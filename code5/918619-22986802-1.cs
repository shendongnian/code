    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
     if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                string iss = item["Status"].Text; // Status is column Uniquename
            }
    }
