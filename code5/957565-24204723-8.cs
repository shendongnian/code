    protected void rptconsole_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType  ==ListItemType.AlternatingItem)
            {
               HtmlTableCell tdPrice = e.Item.FindControl("price") as HtmlTableCell;    
               tdPrice.InnerText = Convert.ToDecimal(tdPrice.InnerText).ToString("C2"); //2dp Number or any value you want
            }
        }
