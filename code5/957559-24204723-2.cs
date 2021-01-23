    protected void rptconsole_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType  ==ListItemType.AlternatingItem)
            {
               HtmlTableCell tdPrice = e.Item.FindControl("price") as HtmlTableCell;    
               tdPrice.InnerText = tdPrice.InnerText.ToString("0.00"); //2dp Number or any value you want
            }
        }
