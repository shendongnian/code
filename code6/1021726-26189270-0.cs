    private void rgDetailItems_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
    
    if (e.Item is GridFooterItem)
     {
        GridFooterItem footerItem = (GridFooterItem)e.Item;
        footerItem["DtlTransAmount"].Text = "Total Amount: $: " + total.ToString();
     }
    }
