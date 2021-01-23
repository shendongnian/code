    protected void grdvPos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlTableCell td = (HtmlTableCell)e.Item.FindControl("TD1");
                if (td.InnerText.Contains("Decreased"))
                    td.Attributes.Add("style", "background-color:Red;");
                else
                    td.Attributes.Add("style", "background-color:Green;");
            }
        }
