    protected void pageResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            PageResult p = e.Item.DataItem as PageResult;
            ((Label)e.Item.FindControl("lblSearchResult")).Text = p.HighlightedText;
        }
    }
