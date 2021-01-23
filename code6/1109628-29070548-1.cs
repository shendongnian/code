    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlTableCell td = (HtmlTableCell)e.Item.FindControl("TD1"); 
                if ("YOUR CONDITION")
                    td.Attributes.Add("style", "background-color:Green;");
                else
                  td.Attributes.Add("style", "background-color:Yellow;");
             }
    }
