    protected void datalstProfileCount_ItemDataBound(Object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if(e.Item.ItemIndex <=1)
            {
                var headerRow = (System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("trHeader");
                if(headerRow != null)
                {
                    headerRow.Style.Add(HtmlTextWriterStyle.Visibility, "");
                }
            }
        }
    }
